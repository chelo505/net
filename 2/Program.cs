using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using net2_quiz2_დავით_ჭელიძეwebapi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(TypeAdapterConfig.GlobalSettings);
builder.Services.AddSingleton<IMapper, Mapper>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<RequestLoggingMiddleware>();

app.MapControllers();

app.Run();

