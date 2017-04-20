using System;
using System.Security.Cryptography;
using System.Text;

namespace BastardFat.PersonalInfo.DatabaseInteraction.Tools
{
    public static class CryptHelper
    {
        public static string SHA1(string param)
        {
            var buffer = Encoding.Default.GetBytes(param);
            var cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
            return BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");
        }
    }
}