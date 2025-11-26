using clean_architecture_demo_v2.Application.Blogs.Commands.CreateBlog;
using clean_architecture_demo_v2.Application.Blogs.Commands.DeleteBlog;
using clean_architecture_demo_v2.Application.Blogs.Commands.UpdateBlog;
using clean_architecture_demo_v2.Application.Blogs.Queries.GetBlogById;
using clean_architecture_demo_v2.Application.Blogs.Queries.GetBlogs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clean_architecture_demo_v2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await Mediator.Send(new GetBlogQuery());

            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await Mediator.Send(new GetBlogByIdQuery() { BlogId = id });
            if(blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCommand command)
        {
            var createdBlog = await Mediator.Send(command);
            return CreatedAtAction(
                        nameof(GetById),
                        new { id = createdBlog.Id },
                        createdBlog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBlogCommand command)
        {
            command.Id = id;

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var result = await Mediator.Send(new DeleteBlogCommand { Id = id });
            if(result == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }

    }
}
