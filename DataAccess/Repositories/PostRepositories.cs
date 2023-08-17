using Application.Abstractions;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PostRepositories : IPostRepository
    {
        public Task<Post> CreatePost(Post toCreate)
        {
            throw new NotImplementedException();
        }

        public Task DeletePost(int postId)
        {
            throw new NotImplementedException();
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
