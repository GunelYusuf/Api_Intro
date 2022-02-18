using FluentValidation;

namespace WebApi.ProductDto
{
    public class ProductCreateDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsDelete { get; set; }

    }

    public class ProductCreateValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Don't empty")
                .MaximumLength(50)
                .WithMessage("Cannot be over 50");

            RuleFor(p => p.Price)
                .GreaterThan(30)
                .WithMessage("Cannot be priced below 30");

        }
    }
}
