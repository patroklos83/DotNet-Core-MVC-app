using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using WebApplicationExample.DTO;
using WebApplicationExample.Models;
using WebApplicationExample.Repository;

namespace WebApplicationExample.Service
{
    public class ArticleService
    {

        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ArticleService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ArticleDTO GetArticle(string id)
        {
            var article = _repository.GetArticle(id);
            if (article == null)
            {
                return null;
            }

            return _mapper.Map<ArticleDTO>(article);
        }

        public List<ArticleDTO> GetArticles()
        {
            var articles = _repository.GetArticles();
            if (articles == null)
            {
                return null;
            }

           return articles.Select(a => _mapper.Map<ArticleDTO>(a)).ToList();
        }

        public ArticleDTO Save(ArticleDTO articleDTO)
        {
            ITransaction tx = null;

            try
            {
                tx = _repository.BeginTransaction();

                Article article = _mapper.Map<Article>(articleDTO);

                _repository.Save(article);
                _repository.Commit();

                articleDTO = _mapper.Map<ArticleDTO>(article);
                return articleDTO;
            }

            catch (Exception ex)
            {
                if (tx != null)
                    tx.Rollback();

                throw;
            }
        }

        public void Delete(ArticleDTO articleDTO)
        {
            ITransaction tx = null;

            if (articleDTO == null)
            {
                return;
            }

            Article article = _mapper.Map<Article>(articleDTO);

            var articles = _repository.GetArticles();
            if (articles == null)
            {
                return;
            }

            var articleP = articles.FirstOrDefault(a => a.Id == article.Id && a.IsDeleted == 0);
            if (articleP == null)
            {
                return;
            }

            try
            {
                tx = _repository.BeginTransaction();
                articleP.IsDeleted = 1;
                _repository.Save(articleP);
                _repository.Commit();
            }

            catch (Exception ex)
            {
                if (tx != null)
                    tx.Rollback();

                throw;
            }
        }
    }
}
