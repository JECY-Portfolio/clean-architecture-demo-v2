using clean_architecture_demo_v2.Application.Blogs.Queries.GetBlogs;
using MediatR;

namespace clean_architecture_demo_v2.Application.Blogs.Queries.GetBlogById
{
    public class GetBlogByIdQuery : IRequest<BlogVm>
    {
        public int BlogId { get; set; }
    }
}
