     public static string EncodePassword(string pass, string salt) //encrypt password
       {
          byte[] bytes = Encoding.Unicode.GetBytes(pass);
          byte[] src = Encoding.Unicode.GetBytes(salt);
          byte[] dst = new byte[src.Length + bytes.Length];
          System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
          System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
          HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
          byte[] inArray = algorithm.ComputeHash(dst);
          //return Convert.ToBase64String(inArray);
          return EncodePasswordMd5(Convert.ToBase64String(inArray));
       }
      public static string EncodePasswordMd5(string pass) //Encrypt using MD5
       {
          Byte[] originalBytes;
          Byte[] encodedBytes;
          MD5 md5;
          //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
          md5 = new MD5CryptoServiceProvider();
          originalBytes = ASCIIEncoding.Default.GetBytes(pass);
          encodedBytes = md5.ComputeHash(originalBytes);
          //Convert encoded bytes back to a 'readable' string
          return BitConverter.ToString(encodedBytes);
      }
