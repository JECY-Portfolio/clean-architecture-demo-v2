
using clean_architecture_demo_v2.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean_architecture_demo_v2.Application.Blogs.Queries.GetBlogs
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<BlogVm>>
    {
        private readonly IBlogRepository _blogRepository;
        public GetBlogQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public IBlogRepository BlogRepository { get; }

        public async Task<List<BlogVm>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogRepository.GetAllBlogsAsync();
           var blogList =  blogs.Select(x => new BlogVm
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Author = x.Author
            }).ToList();

            return blogList;
        }
    }
}
