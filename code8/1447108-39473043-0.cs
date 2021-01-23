    public static bool ValidatePassword(string inputPassword, string storedPassword, string salt)
            {
                // crypt the entered password and stored password
                string CryptedInput = Crypter.Blowfish.Crypt(Encoding.ASCII.GetBytes(inputPassword), salt);
                string CryptedPassword = Crypter.Blowfish.Crypt(Encoding.ASCII.GetBytes(storedPassword), salt);
    
                // compare the crypted passwords
                return string.Equals(CryptedInput, CryptedPassword);
            }
