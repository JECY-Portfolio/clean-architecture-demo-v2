using AutoMapper;
using clean_architecture_demo_v2.Application.Blogs.Queries.GetBlogs;
using clean_architecture_demo_v2.Domain.Entity;
using clean_architecture_demo_v2.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean_architecture_demo_v2.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogVm>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<BlogVm> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blogEntity = new Blog() { Name = request.Name, Description = request.Description, Author = request.Author };
            var result = await _blogRepository.CreateBlogAsync(blogEntity);

            return _mapper.Map<BlogVm>(result);
        }
    }
}
