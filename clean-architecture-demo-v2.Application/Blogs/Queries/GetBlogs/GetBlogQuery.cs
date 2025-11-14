
using MediatR;

namespace clean_architecture_demo_v2.Application.Blogs.Queries.GetBlogs
{
    public class GetBlogQuery : IRequest<List<BlogVm>>
    {
    }
}
