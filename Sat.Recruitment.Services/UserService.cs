using Sat.Recruitment.Common.Web;
using Sat.Recruitment.Data.Interfaces;
using Sat.Recruitment.Dto;
using Sat.Recruitment.Services.Factories;
using Sat.Recruitment.Services.Utils;
using Sat.Recruitment.Services.Validators;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result> CreateUserAsync(UserRequest userRequest)
        {
            #region Validations
            UserRequestValidator userRequestValidator = new UserRequestValidator();
            var result = await userRequestValidator.ValidateAsync(userRequest);
            if (!result.IsValid)
            {
                var errorMessage = string.Join(", ", result.Errors.Select(x => x.ErrorMessage));
                Debug.WriteLine(errorMessage);
                return Result.Fail(errorMessage);
            }

            string checkResult = await CheckDuplicated(userRequest);
            if (!string.IsNullOrEmpty(checkResult))
            {
                Debug.WriteLine(checkResult);
                return Result.Fail(checkResult);
            }
            #endregion

            var user = UserFactory.CreateEntity(userRequest);
            
            user.SetUserMoneyGift();

            await _userRepository.AddAsync(user);

            Debug.WriteLine("User Created");
            return Result.Success("User Created");
        }

        private async Task<string> CheckDuplicated(UserRequest userRequest)
        {
            var duplicatedUsers = (await _userRepository.GetAllAsync()).Where(x => (x.Email == userRequest.Email || x.Phone == userRequest.Phone)
                                                                                || (x.Name == userRequest.Name && x.Address == userRequest.Address));
            if (duplicatedUsers.Any())
            {
                return "The user is duplicated";
            }

            return string.Empty;
        }
    }
}