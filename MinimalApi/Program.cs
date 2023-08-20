using Application.Abstractions;
using Application.Posts.Commands;
using Application.Posts.Queries;
using DataAccess;
using DataAccess.Repositories;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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

app.MapPost("api/posts",async (IMediator mediator, [FromBody]Post post ) =>
{
    var createPost = new CreatePost { PostContent = post.Content };
    var createdPost = await mediator.Send(createPost);
    return Results.CreatedAtRoute("GetPostById",new {createdPost.Id}, createdPost);
});

app.Run();

