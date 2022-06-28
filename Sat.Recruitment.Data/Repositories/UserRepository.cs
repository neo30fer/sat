using Microsoft.Extensions.Configuration;
using Sat.Recruitment.Data.Interfaces;
using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Sat.Recruitment.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<User>> GetAllAsync()
        {
            string[] lines = await File.ReadAllLinesAsync(GetFilePath());
            List<User> _users = new List<User>();

            foreach (string line in lines)
            {
                var user = ConvertRecordToUser(line);
                if (user != null)
                {
                    _users.Add(user);
                }
            }

            return _users;
        }

        public async Task AddAsync(User user)
        {
            await File.AppendAllTextAsync(GetFilePath(), $"\n{ConvertUserToRecord(user)}");
        }

        private User ConvertRecordToUser(string record)
        {
            if (string.IsNullOrEmpty(record))
            {
                return null;
            }

            string[] fields = record.Split(',');

            if (fields.Length != 6)
            {
                return null;
            }

            // Other validations can be added as needed...

            return new User
            {
                Name = fields[0],
                Email = fields[1],
                Phone = fields[2],
                Address = fields[3],
                UserType = Enum.Parse<UserTypes>(fields[4]),
                Money = decimal.Parse(fields[5]),
            };
        }

        private string ConvertUserToRecord(User user)
        {
            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.Name},{user.Email},{user.Phone},{user.Address},{user.UserType},{user.Money}";
        }

        private string GetFilePath()
        {
            return $"{Directory.GetCurrentDirectory()}/Files/{_configuration.GetSection("FileName").Value}";
        }
    }
}
