     public string DecryptFile(string inputFile)
            {
    
                const string password = @"*PROJECT-CONFIG-FILE-ENCRYPTED-2016*"; // Your Key Here
    
                var cryptFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                var fsEncrypt = new FileStream(inputFile, FileMode.Create);
    
                var rmCrypto = new RijndaelManaged();
    
                Rfc2898DeriveBytes pwdGen = new Rfc2898DeriveBytes(password, 10000);
                rmCrypto.BlockSize = 256;
    
                byte[] key = pwdGen.GetBytes(rmCrypto.KeySize / 8);   //This will generate a 256 bits key
                byte[] iv = pwdGen.GetBytes(rmCrypto.BlockSize / 8);  //This will generate a 256 bits IV
    
    // The mistake is that he was calling the CreateEncryptor function ()
                    var cs = new CryptoStream(fsEncrypt, rmCrypto.CreateDecryptor(key, iv), CryptoStreamMode.Read);
    
                StreamReader streamReader = new StreamReader(cs);
                string conexion = streamReader.ReadLine();
    
    
                streamReader.Close();
                cs.Close();
                fsEncrypt.Close();
    
                return conexion;
            }
