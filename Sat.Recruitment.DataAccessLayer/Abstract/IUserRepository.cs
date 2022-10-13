using Sat.Recruitment.Core;
using Sat.Recruitment.DataAccessLayer.Models;
using System.Threading.Tasks;

namespace Sat.Recruitment.DataAccessLayer.Abstract
{
    public interface IUserRepository
    {
        public Task<Result> Insert(User newUser);
    }
}
