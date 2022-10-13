using System;
using System.Collections.Generic;
using System.Net;
using System.Numerics;
using System.Text;
using System.Xml.Linq;
using Sat.Recruitment.DataAccessLayer.Models;
using Sat.Recruitment.Core;
using Sat.Recruitment.DataAccessLayer.Abstract;
using Sat.Recruitment.Business.Abstract;
using System.Threading.Tasks;

namespace Sat.Recruitment.Business.Concrete
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result> Insert(User newUser)
        {
            var parts = newUser.Email.Split('@');
            newUser.Email = string.Join("@", new string[] { parts[0].Replace(".", "").Replace("+", ""), parts[1] });

            switch (newUser.UserType)
            {
                case "Normal":
                    if (newUser.Money > 100)
                        //If new user is normal and has more than USD100
                        newUser.Money *= 1 + Convert.ToDecimal(0.12);
                    else if (newUser.Money > 10)
                        newUser.Money *= 1 + Convert.ToDecimal(0.8);
                    break;
                case "SuperUser":
                    newUser.Money *= 1 + Convert.ToDecimal(0.20);
                    break;
                case "Premium":
                    newUser.Money *= 3;
                    break;
                default:
                    break;
            }

            return await _userRepository.Insert(newUser);
        }
    }
}
