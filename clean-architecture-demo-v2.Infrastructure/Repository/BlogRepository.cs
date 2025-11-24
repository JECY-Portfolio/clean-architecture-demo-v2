using clean_architecture_demo_v2.Domain.Entity;
using clean_architecture_demo_v2.Domain.Repository;
using clean_architecture_demo_v2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace clean_architecture_demo_v2.Infrastructure.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _blogDbContext;

        public BlogRepository(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }
        public async Task<Blog> CreateBlogAsync(Blog blog)
        {
            await _blogDbContext.Blogs.AddAsync(blog);
            await _blogDbContext.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteBlogAsync(int id)
        {
            return await _blogDbContext.Blogs
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<List<Blog>> GetAllBlogsAsync()
        {
            return await _blogDbContext.Blogs.ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _blogDbContext.Blogs.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> UpdateBlogAsync(int id, Blog blog)
        {
            return await _blogDbContext.Blogs
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(p => p.Id, blog.Id)
                    .SetProperty(p => p.Name, blog.Name)
                    .SetProperty(p => p.Description, blog.Description)
                    .SetProperty(p => p.Author, blog.Author)
                );
        }
    }
}
