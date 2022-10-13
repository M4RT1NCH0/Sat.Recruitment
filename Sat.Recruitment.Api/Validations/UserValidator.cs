using FluentValidation;
using Sat.Recruitment.DataAccessLayer.Models;

namespace Sat.Recruitment.Api.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name).NotEmpty();
            RuleFor(user => user.Email).EmailAddress().NotEmpty();
            RuleFor(user => user.Address).NotEmpty();
            RuleFor(user => user.Phone).NotEmpty();
            RuleFor(user => user.UserType).NotEmpty();
            RuleFor(user => user.Money).NotEmpty();
        }
    }
}

