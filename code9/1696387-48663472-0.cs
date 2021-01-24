    static void Main(string[] args)
            {
    
                var enCrypto= Encyrpt("AllenLi","qwefdssdf");
                var deCrypto=lDecyrpt(enCrypto,"qwefdssdf");
    
                System.Console.WriteLine(deCrypto);
            }
            private static readonly byte[] salt=Encoding.Unicode.GetBytes("salts@@");
            public static string Encyrpt(string plainText,string password){
                byte[] plainBytes=Encoding.Unicode.GetBytes(plainText);
                var aes=Aes.Create();
    
                //generating keys ,IV
                var pbkdf2=new Rfc2898DeriveBytes(password,salt,2000);
                var aesKey=pbkdf2.GetBytes(32);
                var aesIV=pbkdf2.GetBytes(16);
                
                aes.Key = aesKey;
    	        aes.IV = aesIV;
    
                var ms =new MemoryStream();
                using(var cs=new CryptoStream(ms,aes.CreateEncryptor(),CryptoStreamMode.Write)){
                        cs.Write(plainBytes,0,plainBytes.Length);
    
                };
                return Convert.ToBase64String(ms.ToArray());
    
            }
            public static string lDecyrpt(string cryptoText,string password)
            {
                byte[] cryptoBytes=Convert.FromBase64String(cryptoText);
                var aes=Aes.Create();
    
                //generating keys ,IV
                var pbkdf2=new Rfc2898DeriveBytes(password,salt,2000);
                var aesKey=pbkdf2.GetBytes(32);
                var aesIV=pbkdf2.GetBytes(16);
    
                aes.Key = aesKey;
    	        aes.IV = aesIV;
    
                var ms =new MemoryStream();
                using(var cs=new CryptoStream(ms,aes.CreateDecryptor(),CryptoStreamMode.Write)){
    
    
                    cs.Write(cryptoBytes,0,cryptoBytes.Length);
                };
                return Encoding.Unicode.GetString(ms.ToArray());
    
            }
