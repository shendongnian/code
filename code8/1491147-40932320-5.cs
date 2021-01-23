    public string TryLogin(string username, string password) {
        // this will return user email upon succesfull logging in
        using (var sr = new StreamReader("data\\" + dir + "\\data.ls")){
            string line = string.Empty;
            while((line = sr.ReadLine()) != null) {
                string[] extracted = string.Split(";");
                if(extracted[0] == Encryption.Encrypt.encrypt(username) && extracted[1] == Encryption.Encrypt.encrypt(password)) {
                    return Encryption.Encrypt.decrypt(extracted[1]);
                }
            }
        }
        return string.Empty;
    }
