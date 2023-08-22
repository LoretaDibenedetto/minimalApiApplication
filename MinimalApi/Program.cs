
using Application.Posts.Commands;
using Application.Posts.Queries;

using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

using MinimalApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices();


var app = builder.Build();



app.UseHttpsRedirection();

app.RegisterEndpointDefinition();


app.Run();

