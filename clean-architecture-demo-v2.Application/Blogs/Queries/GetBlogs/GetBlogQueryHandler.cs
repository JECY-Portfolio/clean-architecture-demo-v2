
using AutoMapper;
using clean_architecture_demo_v2.Domain.Repository;
using MediatR;

namespace clean_architecture_demo_v2.Application.Blogs.Queries.GetBlogs
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<BlogVm>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public GetBlogQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public IBlogRepository BlogRepository { get; }

        public async Task<List<BlogVm>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogRepository.GetAllBlogsAsync();
           //var blogList =  blogs.Select(x => new BlogVm
           // {
           //     Id = x.Id,
           //     Name = x.Name,
           //     Description = x.Description,
           //     Author = x.Author
           // }).ToList();

           var blogList =  _mapper.Map<List<BlogVm>>(blogs);

            return blogList;
        }
    }
}
