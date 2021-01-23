    private void GetPrivateKeyFromP12(string path, string passWord)
            {
                //this.mKeyStoreEntities = PKCSUtils.extractEntities(privateKeyFilePath, privateKeyPassword);
                /**
                 * Java has a minimum requirement for keystore password lengths.  Utilities like KeyChain will
                 * allow you to specify less but then you will receive an obscure java error when trying to
                 * load the keystore.  Check for it here and throw a meaningful error
                 */
    
                //X509Certificate certificate;
                //ECPrivateKey privateKey;
    
                using (StreamReader reader = new StreamReader(path))
                {
                    var fs = reader.BaseStream;
                    GetMerchantIdentifierField(fs);
    
                    fs.Position = 0;
                    GetPrivateKey(fs, passWord);
                }
            }
    
            private void GetPrivateKey(Stream fs, string passWord)
            {
                Pkcs12Store store = new Pkcs12Store(fs, passWord.ToCharArray());
    
                foreach (string n in store.Aliases)
                {
                    if (store.IsKeyEntry(n))
                    {
                        AsymmetricKeyEntry asymmetricKey = store.GetKey(n);
    
                        if (asymmetricKey.Key.IsPrivate)
                        {
                            this.merchantPrivateKey = asymmetricKey.Key as ECPrivateKeyParameters;
                        }
                    }
                }
            }
