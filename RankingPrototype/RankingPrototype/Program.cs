using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RankingCore.Persistence.Contexts;
using RankingCore.Persistence.Repositories;
using RankingCore.Services;
using RankingPrototype.Filters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRankingService, RankingService>();
builder.Services.AddDbContext<RankingContext>();
builder.Services.AddScoped<IPlayerRepository,PlayerRepository>();
builder.Services.AddScoped<IScoreRepository, ScoreRepository>();
builder.Services.AddScoped<RankingExceptionFilter>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
