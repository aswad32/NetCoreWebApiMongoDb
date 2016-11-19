using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BlogReaderApi.Domain;
using BlogReaderApi.Model;

namespace BlogReaderApi.Controllers
{
    [Route("api/[controller]")]
    public class ArticleController : Controller
    {
        private IArticleModel _articleModel;

        public ArticleController(IArticleModel articleModel) 
        {
            _articleModel = articleModel;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Article> Get()
        {
            var result = _articleModel.All(1, 10); //_mongoRepository.All<Article>(1, 10).AsEnumerable();
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Article Get(string id)
        {
            return _articleModel.Single(id);
        }

    }
}
