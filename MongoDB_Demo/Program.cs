using MongoDB_Demo.Data;
using MongoDB_Demo.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
MongoCRUD db = new MongoCRUD("AzureCourses");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Post
app.MapPost("/course", async (Courses course) =>
{

    var testDB = await db.AddCourse("Courses", course);
    return Results.Ok(testDB);
});

// Get all

app.MapGet("/courses", async () =>
{
    var courses = await db.GetAllCourses("Courses");
    return Results.Ok(courses);
});


// Get by Id

app.MapGet("/course/{id}", async (Guid id) =>
{
    var course = await db.GetCourseById("Courses", id);
    return Results.Ok(course);
});


// Update

app.MapPut("/course/{id}", async (Guid id, Courses updatedCourse) =>
{
    var course = await db.UpdateCourse("Courses", id, updatedCourse);
    return Results.Ok(course);
});


//Delete

app.MapDelete("/course/{id}", async (Guid id) =>
{
    var course = await db.DeleteCourse("Courses", id);
    return Results.Ok(course);
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}