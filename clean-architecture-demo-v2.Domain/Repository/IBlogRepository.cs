using clean_architecture_demo_v2.Domain.Entity;

namespace clean_architecture_demo_v2.Domain.Repository
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllBlogsAsync();
        Task<Blog> GetByIdAsync(int id);
        Task<Blog> CreateBlogAsync(Blog blog);
        Task<int> UpdateBlogAsync(int id, Blog blog);
        Task<int> DeleteBlogAsync(int id);
    }
}
