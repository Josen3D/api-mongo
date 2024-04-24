using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api_mongo_prueba.Models
{
    // create attributes and specify elements in mongoDB document
    public class VisualProblems
    {
        [BsonId] // indicate attribute as ID
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)] // indicate the element name in document, and specify the data type.
        public string? Id { get; set; }

        [BsonElement("name"), BsonRepresentation(BsonType.String)] // indicate the element name in document, and specify the data type.
        public string? Name { get; set; }

        [BsonElement("description"), BsonRepresentation(BsonType.String)] // indicate the element name in document, and specify the data type.
        public string? Description { get; set; }

        [BsonElement("symptoms")]
        public List<string>? Symptoms { get; set; }

        [BsonElement("causes")]
        public List<string>? Causes { get; set; }

        [BsonElement("treatments")]
        public List<string>? Treatments { get; set; }

        [BsonElement("to_consider"), BsonRepresentation(BsonType.String)]
        public string? ToConsider { get; set; }

    }
}
