using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using NHibernate;
using System.Collections.Generic;
using WebApplicationExample.DTO;
using WebApplicationExample.HibernateConfigurations;
using WebApplicationExample.Models;
using WebApplicationExample.Service;

namespace WebApplicationExample.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ArticleService _service;

        public ArticleController(ArticleService service)
        {
            _service = service;
        }

        [Route("Articles")]
        public ActionResult Articles()
        {
            var articles = _service.GetArticles();
            if (articles == null)
            {
                return View();
            }

            List<ArticleDTO> articlesResult = articles.ToList();
            ViewData["Articles"] = articlesResult;

            return View(articlesResult);
        }

        // GET: ArticleController/5
        [Route("Article")]
        [Route("Article/{id?}")]
        public ActionResult Index(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View();
            }

            var article = _service.GetArticle(id);
            if (article == null)
            {
                return View();
            }

            ViewData["Article"] = article;

            return View(article);
        }

        [HttpPost]
        [Route("Article/save")]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ArticleDTO articleDTO)
        {
            ModelState.Remove("Id"); // do not validate Id field
            if (!ModelState.IsValid)
            {
                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
                return Redirect("../Article/?mode=create");
            }
           
            articleDTO = _service.Save(articleDTO);
            return Redirect(string.Format("{0}", articleDTO.Id));
        }

        // POST: ArticleController/Delete
        [HttpPost]
        [Route("Article/delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ArticleDTO articleDTO)
        {
            _service.Delete(articleDTO);
            return Redirect("/Articles");
        }

    }
}
