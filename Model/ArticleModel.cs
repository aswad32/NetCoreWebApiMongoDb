using System.Collections.Generic;
using BlogReaderApi.Domain;
using BlogReaderApi.Repository;
using MongoDB.Bson;

namespace BlogReaderApi.Model
{
    public interface IArticleModel 
    {
        Article Single(string Id);
        IEnumerable<Article> All(int page, int pageSize);
    }

    public class ArticleModel: IArticleModel
    {
        private IRepository _mongoDbRepository;
        public ArticleModel(IRepository mongoDbRepository) 
        {
            _mongoDbRepository = mongoDbRepository;
        }

        public Article Single(string Id) 
        {
            var collection = _mongoDbRepository.Single<Article>(x => x.Id == ObjectId.Parse(Id));
            return collection;
        }

        public IEnumerable<Article> All(int page, int pageSize) 
        {
            var collection = _mongoDbRepository.All<Article>(page, pageSize);
            return collection;
        }
    }
}