using NHibernate;
using WebApplicationExample.Models;

namespace WebApplicationExample.Repository
{
    public interface IRepository
    {
        ITransaction BeginTransaction();
        Task Commit();
        Task Rollback();
        void CloseTransaction();
        Task Save(Article entity);
        Task Delete(Article entity);
        IList<Article> GetArticles();
        Article? GetArticle(string id);
    }

}
