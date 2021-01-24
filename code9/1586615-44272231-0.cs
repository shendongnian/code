    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    
    namespace _3DES
    {
        class Program
        {
    
            public static string Encrypt(string strValue)
            {
                const string DES3_KEY = "A0498F07C46808173894BB976F9726477CC0913D87DE912A";
                const string DES3_IV = "0A9B11D6FEE830A9";
                TripleDESCryptoServiceProvider objCryptoProvider;
                string str = "";
                if (strValue.Length > 0)
                {
                    objCryptoProvider = new TripleDESCryptoServiceProvider();
                    objCryptoProvider.Mode = CipherMode.CBC;
                    objCryptoProvider.Padding = PaddingMode.PKCS7;
                    byte[] bytes1 = Encoding.Default.GetBytes(HexDecode(DES3_KEY));
                    byte[] bytes2 = Encoding.Default.GetBytes(HexDecode(DES3_IV));
                    MemoryStream memoryStream = new MemoryStream();
                    CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, objCryptoProvider.CreateEncryptor(bytes1, bytes2), CryptoStreamMode.Write);
                    StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream);
                    streamWriter.Write(strValue);
                    streamWriter.Flush();
                    cryptoStream.FlushFinalBlock();
                    string strValue1 = Encoding.Default.GetString(memoryStream.GetBuffer(), 0, checked((int)memoryStream.Length));
                    str = HexEncode(strValue1);
                }
                return str;
            }
    
            public static string Decrypt(string strValue)
            {
                const string DES3_KEY = "A0498F07C46808173894BB976F9726477CC0913D87DE912A";
                const string DES3_IV = "0A9B11D6FEE830A9";
                TripleDESCryptoServiceProvider objCryptoProvider;
                string str = "";
                if (strValue.Length > 0)
                {
                    objCryptoProvider = new TripleDESCryptoServiceProvider();
                    objCryptoProvider.Mode = CipherMode.CBC;
                    objCryptoProvider.Padding = PaddingMode.PKCS7;
                    byte[] bytes1 = Encoding.Default.GetBytes(HexDecode(DES3_KEY));
                    byte[] bytes2 = Encoding.Default.GetBytes(HexDecode(DES3_IV));
                    string s;
                    s = HexDecode(strValue);
                    str = new StreamReader((Stream)new CryptoStream((Stream)new MemoryStream(Encoding.Default.GetBytes(s)), objCryptoProvider.CreateDecryptor(bytes1, bytes2), CryptoStreamMode.Read)).ReadToEnd();
                }
                return str;
            }
    
            public static string HexEncode(string strValue)
            {
                string str = "";
                if (strValue.Length > 0)
                {
                    byte[] bytes = Encoding.Default.GetBytes(strValue);
                    int num = 0;
                    int upperBound = bytes.GetUpperBound(0);
                    int index = num;
                    while (index <= upperBound)
                    {
                        str += Conversion.Hex(bytes[index]).PadLeft(2, '0');
                        checked { ++index; }
                    }
                }
                return str;
            }
    
            public static string HexDecode(string strValue)
            {
                string str = "";
                if (strValue.Length > 0)
                {
                    strValue = strValue.ToUpper();
                    int num1 = 0;
                    int num2 = checked(strValue.Length - 2);
                    int startIndex = num1;
                    while (startIndex <= num2)
                    {
                        str += Conversions.ToString(Strings.Chr(Conversions.ToInteger("&H" + strValue.Substring(startIndex, 2))));
                        checked { startIndex += 2; }
                    }
                }
                return str;
            }
    
            static void Main(string[] args)
            {
                String encoded = Encrypt("test");
                Console.WriteLine(encoded);
                String plain = Decrypt(encoded);
                Console.WriteLine(plain);
            }
        }
    }
