using FluentValidation;
using lab7_8.Models;

namespace lab7_8.Validators
{
    public class EmployeeModelValidator : AbstractValidator<EmployeeModel>
    {
        public EmployeeModelValidator()
        {
            RuleFor(employee => employee.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");

            RuleFor(employee => employee.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email is not a valid email address.");

            RuleFor(employee => employee.Age)
                .GreaterThanOrEqualTo(18).WithMessage("Age must be at least 18.")
                .LessThanOrEqualTo(65).WithMessage("Age must be less or equal to 65.");

            RuleFor(employee => employee.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.");

            RuleFor(employee => employee.Address)
                .NotEmpty().When(employee => employee.Address != null)
                .WithMessage("Address is required.");

            RuleFor(employee => employee.City)
                .NotEmpty().When(employee => employee.City != null)
                .WithMessage("City is required.");

            RuleFor(employee => employee.Country)
                .NotEmpty().WithMessage("Country is required.");

            RuleFor(employee => employee.Salary)
                .GreaterThanOrEqualTo(0).WithMessage("Salary must be non-negative.");
        }
    }
}
