using System;
using System.Collections.Generic;
using System.Text;

namespace QuizOnline.Common.Infrastructure.Helper
{
    public static class AuthenAccountHelper
    {
        public static void CreatePasswordHash(string Password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (Password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(Password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
            }
        }

        public static bool VerifyPasswordHash(string Password, byte[] storedHash, byte[] storedSalt)
        {
            if (Password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(Password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

    }
}
