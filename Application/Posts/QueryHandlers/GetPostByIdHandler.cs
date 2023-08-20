using Application.Abstractions;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Posts.QueryHandlers
{
    public class GetPostByIdHandler : IRequestHandler<GetPostById, Post>
    {
        private readonly IPostRepository _postRepo;
        public GetPostByIdHandler(IPostRepository postRepo)
        {
            _postRepo = postRepo;
        }

        public async Task<Post> Handle(GetPostById request, CancellationToken cancellationToken)
        {
            return await _postRepo.GetPostById(request.PostId);
        }
    }
}
