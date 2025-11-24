using clean_architecture_demo_v2.Application.Blogs.Common.Mappings;
using clean_architecture_demo_v2.Domain.Entity;

namespace clean_architecture_demo_v2.Application.Blogs.Queries.GetBlogs
{
    public class BlogVm : IMapFrom<Blog>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
