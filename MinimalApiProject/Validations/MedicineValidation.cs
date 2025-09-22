using FluentValidation;
using MinimalApiProject.DTOs;

namespace MinimalApiProject.Validations
{
    public class MedicineValidation : AbstractValidator<MedicineDTO>
    {
        public MedicineValidation()
        {
            RuleFor(model => model.Name)
                .NotEmpty().MaximumLength(100)
                .Must(n => !string.IsNullOrWhiteSpace(n))
                .WithMessage("Name cannot be empty or whitespace!");

            RuleFor(model => model.Dosage)
                .NotEmpty()
                .Matches(@"^\s*\d+(\.\d+)?\s*(IU|mg|g|mcg|ml|kg|l)(\s*,\s*\d+(\.\d+)?\s*(IU|mg|g|mcg|ml|kg|l))*\s*$")
                .WithMessage("Dosage must be a valid unit (IU, mg, g, mcg, ml, kg, l)");

            RuleFor(model => model.Description)
                .MaximumLength(500)
                .When(d => !string.IsNullOrEmpty(d.Description));

            RuleFor(model => model.ExpDate)
                .NotEmpty()
                .Must(d => d >= DateOnly.FromDateTime(DateTime.Now))
                .WithMessage("Old medicines cannot be added!");

            RuleFor(model => model.Quantity)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(1000);
        }
    }
}
