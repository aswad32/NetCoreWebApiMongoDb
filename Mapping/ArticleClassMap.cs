using BlogReaderApi.Domain;
using MongoDB.Bson.Serialization;

namespace BlogReaderApi.Mapping
{
    public class ArticleClassMap: MongoDbClassMap<Article>
    {
        public override void Map(BsonClassMap<Article> cm) 
        {
            cm.AutoMap();
            cm.MapIdProperty(c => c.Id);

            cm.MapProperty(c => c.Title).SetElementName("title");
            cm.MapProperty(c => c.Author).SetElementName("author");
            cm.MapProperty(c => c.Summary).SetElementName("summary");
            cm.MapProperty(c => c.Content).SetElementName("content");
            cm.SetIgnoreExtraElements(true);
        }
    }
}