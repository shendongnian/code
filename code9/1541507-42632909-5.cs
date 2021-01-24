    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    					
    public class Program
    {
    	public static void Main()
    	{
    		
    		var key = Encoding.ASCII.GetBytes("0123456789abcdef");//Change the key.
    		
    		var data = Encrypt("Hello World",key);
    		var str = Decrypt(data, key);
    		Console.WriteLine(str);
    	}
    	
    	public static byte[] Encrypt(string plaintext, byte[] key)
        {
    		
            using(var desObj = Rijndael.Create())
    		{
    			desObj.Key = key;
    			desObj.Mode = CipherMode.CFB;
    			desObj.Padding = PaddingMode.PKCS7;
    			using(var ms = new MemoryStream())
    			{
    				//Append the random IV that was generated to the front of the stream.
    				ms.Write(desObj.IV, 0, desObj.IV.Length);
    				
    				//Write the bytes to be encrypted.
    				using(CryptoStream cs = new CryptoStream(ms, desObj.CreateEncryptor(), CryptoStreamMode.Write))
    				{
    		            var plainTextBytes = Encoding.UTF8.GetBytes(plaintext);
    					cs.Write(plainTextBytes, 0, plainTextBytes.Length);
    				}
    				return ms.ToArray();
    			}
    		}
        }
    	
    	public static string Decrypt(byte[] cyphertext, byte[] key)
    	{
    		
            using(MemoryStream ms = new MemoryStream(cyphertext))
    		using(var desObj = Rijndael.Create())
    		{
    			desObj.Key = key;
    			desObj.Mode = CipherMode.CFB;		
    			desObj.Padding = PaddingMode.PKCS7;
    			
    			//Read the IV from the front of the stream and assign it to our object.
    			var iv = new byte[16];
    			var offset = 0;
    			while(offset < iv.Length)
    			{
    				offset += ms.Read(iv, offset, iv.Length - offset);
    			}
    			desObj.IV = iv;
    			
    			//Read the bytes to be decrypted
    			using(var cs = new CryptoStream(ms, desObj.CreateDecryptor(), CryptoStreamMode.Read))
    			using(var sr = new StreamReader(cs, Encoding.UTF8))
    			{
    				return sr.ReadToEnd();
    			}
    		}
    	}
    }
