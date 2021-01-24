        public static string CreateSalt(int size)
        {
            // Generate a cryptographic random number using the cryptographic
            // service provider
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            // Return a Base64 string representation of the random number
            return Convert.ToBase64String(buff);
        }
        public static string CreatePasswordHash(string pwd, string salt)
        {
            string saltAndPwd = String.Concat(pwd, salt);
            string hashedPwd =
                  FormsAuthentication.HashPasswordForStoringInConfigFile(
                                                       saltAndPwd, "SHA1");
            hashedPwd = String.Concat(hashedPwd, salt);
            return hashedPwd;
        }
