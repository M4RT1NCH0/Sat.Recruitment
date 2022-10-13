using Sat.Recruitment.Core;
using Sat.Recruitment.DataAccessLayer.Models;
using System.Threading.Tasks;

namespace Sat.Recruitment.Business.Abstract
{
    public interface IUserService
    {
        public Task<Result> Insert(User newUser);
    }
}
