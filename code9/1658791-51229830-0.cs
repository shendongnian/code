     #region AES Encryption
        public static async Task<bool> EncryptAesFileAsync(StorageFile fileForEncryption, string aesKey256, string iv16lenght)
        {
            
            bool success = false;
            try
            {
                //Initialize key
                IBuffer key = Convert.FromBase64String(aesKey256).AsBuffer();
                var m_iv = Convert.FromBase64String(iv16lenght).AsBuffer();
                SymmetricKeyAlgorithmProvider provider = SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.AesCbcPkcs7);
                var m_key = provider.CreateSymmetricKey(key);
                //secured data
                IBuffer data = await FileIO.ReadBufferAsync(fileForEncryption);
                IBuffer SecuredData = CryptographicEngine.Encrypt(m_key, data, m_iv);
                await FileIO.WriteBufferAsync(fileForEncryption, SecuredData);
                success = true;
            }
            catch (Exception ex)
            {
                success = false;
                DialogHelper.DisplayMessageDebug(ex);
            }
            return success;
        }
        public static async Task<bool> DecryptAesFileAsync(StorageFile EncryptedFile, string aesKey256, string iv16lenght)
        {
            bool success = false;
            try
            {
                //Initialize key
                IBuffer key = Convert.FromBase64String(aesKey256).AsBuffer();
                var m_iv = Convert.FromBase64String(iv16lenght).AsBuffer();
                SymmetricKeyAlgorithmProvider provider = SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.AesCbcPkcs7);
                var m_key = provider.CreateSymmetricKey(key);
                //Unsecured Data
                IBuffer data = await FileIO.ReadBufferAsync(EncryptedFile);
                IBuffer UnSecuredData = CryptographicEngine.Decrypt(m_key, data, m_iv);
                await FileIO.WriteBufferAsync(EncryptedFile, UnSecuredData);
                success = true;
            }
            catch (Exception ex)
            {
                success = false;
                DialogHelper.DisplayMessageDebug(ex);
            }
            return success;
        }
        #endregion
