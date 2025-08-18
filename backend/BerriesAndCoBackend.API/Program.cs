using BerriesAndCoBackend.API;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<WordRepo>();

var app = builder.Build();

app.MapPost("/anagram",
    ([FromBody] GetAnagramsRequest req, [FromServices] WordRepo repo) => repo.GetAnagrams(req.Word));

app.Run();