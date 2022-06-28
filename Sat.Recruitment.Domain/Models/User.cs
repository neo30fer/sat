using Sat.Recruitment.Domain.Enums;

namespace Sat.Recruitment.Domain.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public UserTypes UserType { get; set; }
        public decimal Money { get; set; }
    }
}