using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlogReaderApi.Domain 
{
    public class Article {
        public ObjectId Id {get; set;}
        public string Author { get; set; }
		public string Title { get; set; }
		public string Summary { get; set; }
		public string Content { get; set; }
		public string Link { get; set; }
    }
}