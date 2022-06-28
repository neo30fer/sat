using System;

namespace Sat.Recruitment.Services.Utils
{
    public static class EmailUtils
    {
        public static string NormalizeEmail(this string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return email;
            }

            var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);
            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);
            return string.Join("@", new string[] { aux[0], aux[1] });
        }
    }
}