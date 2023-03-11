using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongo_TheWitcherApi.Models
{
    public class Hunt
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        
        public string Class { get; set; }
        
        public string Species { get; set; }
        
        public int Count { get; set; }
        
        public string Witcher { get; set; }
        
        [BsonElement("index")]
        public int Index { get; set; }
    }
}