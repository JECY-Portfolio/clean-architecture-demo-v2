using FluentValidation;

namespace clean_architecture_demo_v2.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(200).WithMessage("Name must not exceed 200 characters");

            RuleFor(v => v.Description)
                .NotEmpty().WithMessage("Description is required.");

            RuleFor(v => v.Author)
                .NotEmpty().WithMessage("Author is required.")
                .MaximumLength(200).WithMessage("Name must not exceed 200 characters");
        }
    }
}
