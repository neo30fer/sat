using FluentValidation;
using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Dto;
using System.Collections.Generic;

namespace Sat.Recruitment.Services.Validators
{
    public class UserRequestValidator : AbstractValidator<UserRequest>
    {
        public UserRequestValidator()
        {
            RuleFor(userRequest => userRequest.Name).NotNull().NotEmpty().WithMessage("The name is required");
            RuleFor(userRequest => userRequest.Email)
                .NotNull().NotEmpty().WithMessage("The email is required")
                .EmailAddress().WithMessage("The email is invalid");
            RuleFor(userRequest => userRequest.Address).NotNull().NotEmpty().WithMessage("The address is required");
            RuleFor(userRequest => userRequest.Phone).NotNull().NotEmpty().WithMessage("The phone is required");
            RuleFor(userRequest => userRequest.UserType).IsEnumName(typeof(UserTypes)).WithMessage("The user type is invalid"); ;
            RuleFor(userRequest => userRequest.Money)
                .Custom((money, context) =>
                {
                    if ((!(decimal.TryParse(money, out decimal value)) || value < 0))
                    {
                        context.AddFailure($"The money is invalid");
                    }
                });
        }
    }
}
