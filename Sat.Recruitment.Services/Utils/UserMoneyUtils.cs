using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Domain.Models;
using System;

namespace Sat.Recruitment.Services.Utils
{
    public static class UserMoneyUtils
    {
        public static User SetUserMoneyGift(this User user)
        {
            decimal percentage = 0;

            switch (user.UserType)
            {
                case UserTypes.Normal:
                    if (user.Money > 100)
                    {
                        percentage = Convert.ToDecimal(0.12);
                    }
                    else if (user.Money > 10 && user.Money < 100)
                    {
                        percentage = Convert.ToDecimal(0.8);
                    }
                    break;
                case UserTypes.SuperUser:
                    if (user.Money > 100)
                    {
                        percentage = Convert.ToDecimal(0.20);
                    }
                    break;
                case UserTypes.Premium:
                    if (user.Money > 100)
                    {
                        percentage = Convert.ToDecimal(2);
                    }
                    break;
            }

            user.Money += (user.Money * percentage);

            return user;
        }
    }
}
