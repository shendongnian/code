      public string EncryptData(string data)
        {
            if (data == null) 
            throw new ArgumentNullException("data");
            //encrypt data
            var encryptdata = Encoding.Unicode.GetBytes(data);
            byte[] encrypted = ProtectedData.Protect(encryptdata, null, DataProtectionScope.CurrentUser);
            //return as base64 string
            return Convert.ToBase64String(encrypted);
        }
        public string DecryptData(string cipher)
        {
            if (cipher == null) throw new ArgumentNullException("cipher");
            //parse base64 string
            byte[] data = Convert.FromBase64String(cipher);
            //decrypt data
            byte[] decrypted = ProtectedData.Unprotect(data, null, DataProtectionScope.CurrentUser);
            return Encoding.Unicode.GetString(decrypted);
        }
    private void firstTimeAppOpen()
    {
        RegistryKey regkey = Registry.CurrentUser;
        regkey = regkey.CreateSubKey(globalPath); //path
        DateTime dt = DateTime.Now;
        string Date = dt.ToShortDateString(); // get only date not time
        string getDate = EncryptData(Date);
        regkey.SetValue("Install", getDate); //Value Name,Value Data
        regkey.SetValue("Use", getDate); //Value Name,Value Data
    }
