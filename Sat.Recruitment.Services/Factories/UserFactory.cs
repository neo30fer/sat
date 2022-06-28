using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Domain.Models;
using Sat.Recruitment.Dto;
using Sat.Recruitment.Services.Utils;
using System;

namespace Sat.Recruitment.Services.Factories
{
    public static class UserFactory
    {
        public static User CreateEntity(UserRequest userRequest)
        {
            return  new User
            {
                Name = userRequest.Name,
                Email = userRequest.Email.NormalizeEmail(),
                Address = userRequest.Address,
                Phone = userRequest.Phone,
                UserType = Enum.Parse<UserTypes>(userRequest.UserType),
                Money = decimal.Parse(userRequest.Money)
            };
        }
    }
}
