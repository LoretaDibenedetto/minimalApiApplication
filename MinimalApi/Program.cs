using Application.Abstractions;
using Application.Posts.Commands;
using DataAccess;
using DataAccess.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var cs = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<SocialDbContext>(opt => opt.UseSqlServer(cs));
builder.Services.AddScoped<IPostRepository, PostRepositories>();
builder.Services.AddMediatR(typeof(CreatePost));



var app = builder.Build();



app.UseHttpsRedirection();



app.Run();

