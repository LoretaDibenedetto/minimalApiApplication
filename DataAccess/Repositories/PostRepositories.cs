using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PostRepositories : IPostRepository
    {
        private readonly SocialDbContext _ctx;
        public PostRepositories(SocialDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Post> CreatePost(Post toCreate)
        {
            toCreate.DateCreated = DateTime.Now;
            toCreate.LastModifier = DateTime.Now;
            _ctx.Posts.Add(toCreate);
            await _ctx.SaveChangesAsync();
            return toCreate;
        }

        public async Task DeletePost(int postId)
        {
            var post = await _ctx.Posts
            .FirstOrDefaultAsync(p => p.Id == postId);
            if (post == null) return; 
            _ctx.Posts.Remove(post);
            await _ctx.SaveChangesAsync();
        }

        public Task<ICollection<Post>> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPostById(int postId)
        {
            throw new NotImplementedException();
        }

        public Task<Post> UpdatePost(string updatedContent, int postId)
        {
            throw new NotImplementedException();
        }
    }
}
