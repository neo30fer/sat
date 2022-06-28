using Sat.Recruitment.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Recruitment.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task AddAsync(User user);
    }
}
