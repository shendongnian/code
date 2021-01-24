    public bool VerifyPassword(string userEnteredPassword, string dbPasswordHash, string dbPasswordSalt)
        {
            Console.WriteLine(dbPasswordSalt.ToString());
            Console.WriteLine(dbPasswordHash.ToString());
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: userEnteredPassword,
                salt: System.Convert.FromBase64String(dbPasswordSalt),///Encoding.ASCII.GetBytes(dbPasswordSalt),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            Console.WriteLine(hashedPassword.ToString());
            return dbPasswordHash == hashedPassword;
        }
