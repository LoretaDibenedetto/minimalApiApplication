﻿using Application.Abstractions;
using Application.Posts.Commands;
using DataAccess.Repositories;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using MinimalApi.Abstractions;

namespace MinimalApi.Extensions
{
    public static class MinimalApiExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            var cs = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<SocialDbContext>(opt => opt.UseSqlServer(cs));
            builder.Services.AddScoped<IPostRepository, PostRepositories>();
            builder.Services.AddMediatR(typeof(CreatePost));
        }

        public static void RegisterEndpointDefinition (this WebApplication app)
        {
            var endpointDefinition = typeof(Program).Assembly
                .GetTypes()
                .Where(t => t.IsAssignableTo(typeof(IEndpointDefinition)) && !t.IsAbstract && !t.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IEndpointDefinition>();

            foreach(var endpointDef in endpointDefinition) 
            {
                endpointDef.RegisterEndpoints(app); 
            }
        }

    }
}
