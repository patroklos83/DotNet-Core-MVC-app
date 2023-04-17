using NHibernate;
using WebApplicationExample.Models;
using ISession = NHibernate.ISession;

namespace WebApplicationExample.Repository
{
    public class ArticleRepository : IRepository
    {
        private readonly ISession _session;
        private ITransaction? _transaction;

        public ArticleRepository(ISession session)
        {
            _session = session;
        }

        public IList<Article> GetArticles()
        {
            var articles = _session
                .CreateSQLQuery("SELECT * FROM ARTICLES WHERE ISDELETED = 0")
                .AddEntity("ARTICLES", typeof(Article))
                .List<Article>();

            return articles;
        }

        public Article? GetArticle(string id)
        {
            var query = _session
                .CreateSQLQuery("SELECT * FROM ARTICLES WHERE ID = :id")
                .AddEntity(typeof(Article));
            
            var result = query.SetString("id", id).List<Article>();

            return result != null && result.Any() ? result.First() : null;
        }

        public ITransaction BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
            return _transaction;
        }

        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }

        public void CloseTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task Save(Article entity)
        {
            await _session.SaveOrUpdateAsync(entity);
        }

        public async Task Delete(Article entity)
        {
            await _session.DeleteAsync(entity);
        }
    }
}
