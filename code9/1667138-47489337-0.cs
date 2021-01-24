    using DotNetNuke.Security;
    using DotNetNuke.Web.Api;
    using System.Web.Http;
    using ToSic.SexyContent.WebApi;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    
    public class hashController : SxcApiController
    {
        public const int SaltByteSize = 24;
        public const int HashByteSize = 20;
        public const int Pbkdf2Iterations = 1000;
        public const int IterationIndex = 0;
        public const int SaltIndex = 1;
        public const int Pbkdf2Index = 2;
    
        [HttpPost]
        [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.Anonymous)]
        [ValidateAntiForgeryToken]
        public dynamic HashPassword(string password)
        {
            var cryptoProvider = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SaltByteSize];
            cryptoProvider.GetBytes(salt);
    
            var hash = GetPbkdf2Bytes(password, salt, Pbkdf2Iterations, HashByteSize);
            return Pbkdf2Iterations + ":" +
                   Convert.ToBase64String(salt) + ":" +
                   Convert.ToBase64String(hash);
        }
    
        [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.Anonymous)]
        private static byte[] GetPbkdf2Bytes(string password, byte[] salt, int iterations, int outputBytes)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }
    }
