using Application.Abstractions;
using Application.Posts.Commands;
using Application.Posts.Queries;
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

app.MapGet("/api/posts/{id}",async(IMediator mediator, int id) =>
{
    var getPost = new GetPostById { PostId = id };
    var post = await mediator.Send(getPost);
    return Results.Ok(post);

})
    .WithName("GetPostById");

app.Run();

