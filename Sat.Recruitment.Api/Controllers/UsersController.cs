using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Sat.Recruitment.DataAccessLayer.Models;
using Sat.Recruitment.Core;
using Sat.Recruitment.Business.Abstract;
using Sat.Recruitment.Api.Validations;
using FluentValidation.Results;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser(string name, string email, string address, string phone, string userType, string money)
        {
            var newUser = new User
            {
                Name = name,
                Email = email,
                Address = address,
                Phone = phone,
                UserType = userType,
                Money = decimal.Parse(money)
            };

            var validator = new UserValidator();
            ValidationResult result = validator.Validate(newUser);

            if(result.IsValid)
            {
                return await _userService.Insert(newUser);
            }
            else
            {
                var errors = "";
                foreach (var error in result.Errors)
                {
                    errors += error.ErrorMessage;
                }
                var response = new Result()
                {
                    IsSuccess = false,
                    Message = errors,
                };
                return response;
            }
        }
    }
}
