using Sat.Recruitment.Common.Web;
using Sat.Recruitment.Dto;
using System.Threading.Tasks;

namespace Sat.Recruitment.Services
{
    public interface IUserService
    {
        Task<Result> CreateUserAsync(UserRequest userRequest);
    }
}
