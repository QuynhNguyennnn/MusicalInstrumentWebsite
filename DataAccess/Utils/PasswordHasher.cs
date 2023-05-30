using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Utils
{
    public class PasswordHasher
    {


        public string HashPassword(string password)
        {
            Random random = new Random();
            int salt = random.Next(4, 10);
            // Generate a random salt

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hashedPassword;
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            // Verify the password using bcrypt
            bool isPasswordMatch = BCrypt.Net.BCrypt.Verify(password, hashedPassword);

            return isPasswordMatch;
        }
    }
}
