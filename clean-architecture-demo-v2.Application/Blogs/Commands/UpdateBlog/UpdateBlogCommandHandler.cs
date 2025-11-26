using clean_architecture_demo_v2.Domain.Entity;
using clean_architecture_demo_v2.Domain.Repository;
using MediatR;

namespace clean_architecture_demo_v2.Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
    {
        private readonly IBlogRepository _blogRepository;

        public UpdateBlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var updateBlogEntity = new Blog
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Author = request.Author
            };
            return await _blogRepository.UpdateBlogAsync(request.Id, updateBlogEntity);
        }
    }
}
