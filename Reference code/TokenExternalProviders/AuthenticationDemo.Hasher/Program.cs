using System;
using System.Security.Cryptography;

namespace AuthenticationDemo.Hasher
{
    class Program
    {
        static void Main(string[] args)
        {
            var hash = GetHash("123@abc");
        }

        public static string GetHash(string input)
        {
            HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();

            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(input);

            byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);

            return Convert.ToBase64String(byteHash);
        }
    }
}