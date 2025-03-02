using System.Text.Json;
using Dapper;
using Npgsql;
using SeedDatabase;

Console.WriteLine("Seeding the database...");

string _connectionString = "Server=localhost;Port=5432;Database=movies;User ID=course;Password=mySecretPW#";
var connection = new NpgsqlConnection(_connectionString);
await connection.OpenAsync();

var jsonData = File.ReadAllText("/Users/lucian.dunca/dev/learn/RestAPICourse/movies.json");

var data = JsonSerializer.Deserialize<IEnumerable<Movie>>(jsonData);
if (data is null)
{
    Console.WriteLine("No movies found.");
    return;
}

foreach (var movie in data)
{
    // connection.ExecuteAsync(
    //     new CommandDefinition(
    //         """
    //         insert into movies(id, title, slug, yearofrelease)
    //             values(@id, @title, @slug, @yearofrelease);    
    //         """, new
    //         {
    //             id = movie.Id,
    //             title = movie.Title,
    //             slug = movie.Slug,
    //             yearofrelease = movie.YearOfRelease
    //         }));

    foreach (var genre in movie.Genres)
        await connection.ExecuteAsync(
            new CommandDefinition(
                """
                insert into genres(movieid, name)
                values(@movieid, @name)
                """, new
                {
                    movieid = movie.Id,
                    name = genre
                }));
}

Console.WriteLine($"Data seeding is done. Inserted {data.Count()} movies");