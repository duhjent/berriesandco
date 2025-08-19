using BerriesAndCoBackend.API;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<WordRepo>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowVueLocal",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                .WithMethods("POST")
                .AllowAnyHeader();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowVueLocal");
}

app.MapPost("/anagram",
    ([FromBody] GetAnagramsRequest req, [FromServices] WordRepo repo) => repo.GetAnagrams(req.Word))
    .Validate<GetAnagramsRequest>();

app.Run();