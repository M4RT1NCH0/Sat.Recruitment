using Sat.Recruitment.DataAccessLayer.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Sat.Recruitment.Core;
using System.IO;
using Sat.Recruitment.DataAccessLayer.Abstract;

namespace Sat.Recruitment.DataAccessLayer.Concrete
{
    public class UserRepository: IUserRepository
    {
        public Task<Result> Insert(User newUser)
        {
            var result = new Result()
            {
                IsSuccess = true,
                Message = "User Created"
            };
            var reader = ReadUsersFromFile();
            try
            {
                while (reader.Peek() >= 0)
                {
                    var line = reader.ReadLineAsync().Result;
                    var user = new User
                    {
                        Name = line.Split(',')[0].ToString(),
                        Email = line.Split(',')[1].ToString(),
                        Phone = line.Split(',')[2].ToString(),
                        Address = line.Split(',')[3].ToString(),
                        UserType = line.Split(',')[4].ToString(),
                        Money = decimal.Parse(line.Split(',')[5].ToString()),
                    };
                    if (newUser.Equals(user))
                    {
                        result = new Result()
                        {
                            IsSuccess = false,
                            Message = "The user is duplicated"
                        };
                        break;
                    }
                }

                Debug.WriteLine(result.Message);
                return Task.FromResult(result);
            }
            catch(Exception ex)
            {
                Debug.WriteLine("An exception has occurred");
                result = new Result()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
                return Task.FromResult(result);
            }
            finally
            {
                reader.Close();
            }
        }

        private StreamReader ReadUsersFromFile()
        {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }
    }
}
