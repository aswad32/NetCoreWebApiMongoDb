using MongoDB.Bson.Serialization;

namespace BlogReaderApi.Mapping
{
    public abstract class MongoDbClassMap<TEntity>
    {
        protected MongoDbClassMap() 
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(TEntity))) 
            {
                BsonClassMap.RegisterClassMap<TEntity>(Map);
            }

        }

        public abstract void Map(BsonClassMap<TEntity> cm);
    }
}