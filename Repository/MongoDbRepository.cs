using MongoDB.Driver;
using System;

using System.Linq;
using System.Linq.Expressions;
using BlogReaderApi.Helpers;
using Microsoft.Extensions.Configuration;

namespace BlogReaderApi.Repository
{
    public class MongoDbRepository: IRepository
    {

        private readonly IConfigurationSection _configSection;
        private IMongoClient provider;
        private  string DbName { get { return _configSection.GetValue<string>("DbName");} }
        private string ConnectionString { get { return _configSection.GetValue<string>("ConnectionString"); } }
        private  IMongoDatabase _db { get { return provider.GetDatabase(DbName); } }

        public MongoDbRepository(IConfigurationRoot config) 
        {
            _configSection = config.GetSection("Data");
            provider = new MongoClient(ConnectionString);
        }

        public IQueryable<TEntity> All<TEntity>(int page, int pageSize) where TEntity: class, new()
        {
            var collection = GetCollection<TEntity>();
            return PagingExtensions.Page(collection.AsQueryable(), page, pageSize);
        }

        public TEntity Single<TEntity>(Expression<Func<TEntity, bool>> condition) where TEntity : class, new() 
        {
            var collection = GetCollection<TEntity>().AsQueryable().Where(condition).FirstOrDefault(); 
            
            if(collection == null) 
            {
                throw new NullReferenceException("Document not found");
            }

            return collection;
        }

        private IMongoCollection<TEntity> GetCollection<TEntity>() 
        {
            return _db.GetCollection<TEntity>(typeof(TEntity).Name);
        }
    }
}