        public class Encrypt
        {
            public HashedCredential SecurePassword(string password, string salt = "")
            {
                var saltValue = salt;
                if (string.IsNullOrEmpty(salt))
                {
                    saltValue = GenertateSalt();
                }
    
                // Salt the password
                byte[] saltedPassword = Encoding.UTF8.GetBytes(saltValue + password);
    
                // Hash the salted password using SHA256
                SHA512Managed hashstring = new SHA512Managed();
                byte[] hash = hashstring.ComputeHash(saltedPassword);
    
                return new HashedCredential(saltValue, Convert.ToBase64String(hash));
            }
    
            private string GenertateSalt()
            {
                RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
                byte[] salt = new byte[32];
                csprng.GetBytes(salt);
                return Convert.ToBase64String(salt);
            }
        }
    
        public class HashedCredential
        {
            public string SaltValue { get; }
            public string HashValue { get; }
    
            public HashedCredential(string saltValue, string hashValue)
            {
                SaltValue = saltValue;
                HashValue = hashValue;
            }
        }
        [TestMethod]
        public void GenerateSalt()
        {
            // Arrange
            var sut = new Encrypt();
            // Act
            var result = sut.SecurePassword("Test");
            var resultB = sut.SecurePassword("Test", result.SaltValue);
            // Assert
            Console.WriteLine($"resultA:'{result.HashValue}'");
            Console.WriteLine($"resultB:'{resultB.HashValue}'");
            Assert.AreEqual(result.HashValue, resultB.HashValue);
        }
