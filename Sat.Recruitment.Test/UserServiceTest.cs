using Moq;
using Sat.Recruitment.Data.Interfaces;
using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Domain.Models;
using Sat.Recruitment.Dto;
using Sat.Recruitment.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserServiceTest
    {
        private readonly UserService _userService;
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public UserServiceTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task CreateUser_Success()
        {
            MockUserRepository();
            UserRequest userRequest = new UserRequest
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = "124"
            };

            var result = await _userService.CreateUserAsync(userRequest);

            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Message);
        }

        [Fact]
        public async Task CreateUser_DuplicatedUserException()
        {
            MockUserRepository();
            UserRequest userRequest = new UserRequest
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Alvear y Colombres",
                Phone = "+534645213542",
                UserType = "SuperUser",
                Money = "112234"
            };

            var result = await _userService.CreateUserAsync(userRequest);

            Assert.False(result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }

        private void MockUserRepository()
        {
            List<User> users = new List<User>()
            {
                new User
                {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Alvear y Colombres",
                Phone = "+534645213542",
                UserType = UserTypes.SuperUser,
                Money = 112234
                }
            };

            _userRepositoryMock
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(users);
        }
    }
}
