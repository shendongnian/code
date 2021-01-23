    public string ProduceLine(string username, string password, string email){
        return string.Join(";", new string[] { 
            Encryption.Encrypt.encrypt(username),
            Encryption.Encrypt.encrypt(password),
            Encryption.Encrypt.encrypt(email)
        }; // this will return something like "encrypted_username;encrypted_password;encrypted_email"
    }
