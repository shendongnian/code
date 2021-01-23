    public class SecureConfig
    {
        private Configuration applicationConfiguration = null;
        public SecureConfig()
        {
            applicationConfiguration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }
        public SecureConfig(Configuration config)
        {
            applicationConfiguration = config;
        }
        private static string EncryptString(string InputText, string Password)
        {
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(InputText);
            byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
            ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(PlainText, 0, PlainText.Length);
            cryptoStream.FlushFinalBlock();
            byte[] CipherBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string EncryptedData = Convert.ToBase64String(CipherBytes);
            return EncryptedData;
        }
        private static string DecryptString(string InputText, string Password)
        {
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            byte[] EncryptedData = Convert.FromBase64String(InputText);
            byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
            ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream(EncryptedData);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);
            byte[] PlainText = new byte[EncryptedData.Length];
            int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);
            memoryStream.Close();
            cryptoStream.Close();
            string DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);
            return DecryptedData;
        }
        public string GetConnectionString(string password)
        {
            return DecryptString(applicationConfiguration.AppSettings.Settings["connectionString"].Value.Trim().ToString(), password);
        }
        public bool IsEmpty()
        {
            return String.IsNullOrEmpty(applicationConfiguration.AppSettings.Settings["connectionString"].Value.Trim().ToString());
        }
        public void SetConnectionString(String sConnectionString, string password)
        {
            applicationConfiguration.AppSettings.Settings["connectionString"].Value = EncryptString(sConnectionString, password);
            applicationConfiguration.Save(ConfigurationSaveMode.Modified);
            ProtectSection("appSettings");
        }
        private void ProtectSection(String sSectionName)
        {
            ConfigurationSection section = applicationConfiguration.GetSection(sSectionName);
            if (section != null)
            {
                if (!section.IsReadOnly())
                {
                    section.SectionInformation.ForceSave = true;
                    applicationConfiguration.Save(ConfigurationSaveMode.Modified);
                }
            }
        }
    }
