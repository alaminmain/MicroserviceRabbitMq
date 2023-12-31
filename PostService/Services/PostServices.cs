using PostService.Models;

namespace PostService.Services
{
    public class PostServices : IPostService
    {
        private readonly AppDbContext _dbcontext;

        public PostServices(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Post>Add(Post post)
        {
            if(post is not null)
            {
                await _dbcontext.Posts.AddAsync(post);
                await _dbcontext.SaveChangesAsync();
            }
            return post;
        }

        public Post GetById(string id)
        {
            return _dbcontext.Posts.FirstOrDefault(p => p.Id == id);
        }
    }
}
