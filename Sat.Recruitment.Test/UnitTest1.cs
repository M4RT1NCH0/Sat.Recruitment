using System;
using System.Dynamic;

using Microsoft.AspNetCore.Mvc;

using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Business.Concrete;
using Sat.Recruitment.DataAccessLayer.Concrete;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var userRepository = new UserRepository();
            var userService = new UserService(userRepository);
            var userController = new UsersController(userService);

            var result = userController.CreateUser("Mike", "mike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124").Result;


            Assert.Equal(true, result.IsSuccess);
            Assert.Equal("User Created", result.Message);
        }

        [Fact]
        public void Test2()
        {
            var userRepository = new UserRepository();
            var userService = new UserService(userRepository);
            var userController = new UsersController(userService);

            var result = userController.CreateUser("Agustina", "Agustina@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124").Result;


            Assert.Equal(false, result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Message);
        }
    }
}
