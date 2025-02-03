using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_Demo.Models;

public class Courses
{
    [BsonId]
    [BsonRepresentationAttribute(BsonType.String)]
    
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public string Description { get; set; }
    
    public string Link { get; set; }
    
    public string Category { get; set; }
}