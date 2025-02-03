using MongoDB_Demo.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MongoDB_Demo.Data;

public class MongoCRUD
{
    private IMongoDatabase db;

    public MongoCRUD(string database)
    {
        var client = new MongoClient();
        db = client.GetDatabase(database);
    }
    
    
    // Add course
    public async Task<List<Courses>> AddCourse(string table, Courses course)
    {
        var collection = db.GetCollection<Courses>(table);
        await collection.InsertOneAsync(course);
        return collection.AsQueryable().ToList();
    }
    
    
    // Get all courses
    
    // Get course by id
    
    // Update course
    
    // Delete course
}