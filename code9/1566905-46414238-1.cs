    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Numerics;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    class Web
    {
        public const string STEAM_COMMUNITY = "http://steamcommunity.com";
        public const string STEAM_COMMUNITY_GETRSA = "https://steamcommunity.com/login/getrsakey";
        public const string STEAM_COMMUNITY_LOGIN = "https://steamcommunity.com/login/dologin/";
        HttpClient m_HttpClient;
        CookieContainer m_CookieContainer;
        public Web()
        {
            m_CookieContainer = new CookieContainer();
            HttpClientHandler msgHandler = new HttpClientHandler { CookieContainer = m_CookieContainer };
            m_HttpClient = new HttpClient(msgHandler);
        }
        public async Task Login(string pUsername, string pPassword)
        {
            Console.WriteLine("Steamcommunity Login");
            //Get RSA
            Dictionary<string, string> data = new Dictionary<string, string>();
            var request = await m_HttpClient.GetAsync(STEAM_COMMUNITY_GETRSA + "?username=" + pUsername);
            var result = await request.Content.ReadAsStringAsync();
            RsaKey rsaKey = JsonConvert.DeserializeObject<RsaKey>(result);
            
            if(!rsaKey.success)
            {
                Console.WriteLine("Unsuccessfull RSA Key request.");
                return;
            }
            RsaParameters rsaParam = new RsaParameters
            {
                Exponent = rsaKey.publickey_exp,
                Modulus = rsaKey.publickey_mod,
                Password = pPassword
            };
            var encrypted = string.Empty;
            while (encrypted.Length < 2 || encrypted.Substring(encrypted.Length - 2) != "==")
            {
                encrypted = EncryptPassword(rsaParam);
            }
            
            data.Add("username", pUsername);
            data.Add("password", encrypted);
            data.Add("twofactorcode", "");
            data.Add("emailauth", "");
            data.Add("loginfriendlyname", "");
            data.Add("captchagid", "-1");
            data.Add("captcha_text", "");
            data.Add("emailsteamid", "");
            data.Add("rsatimestamp", rsaKey.timestamp);
            data.Add("remember_login", "false");
            request = await m_HttpClient.PostAsync(STEAM_COMMUNITY_LOGIN, new FormUrlEncodedContent(data));
            result = await request.Content.ReadAsStringAsync();
            LoginResult loginResult = JsonConvert.DeserializeObject<LoginResult>(result);
            if(loginResult.success)
            {
                IEnumerable<Cookie> responseCookies = m_CookieContainer.GetCookies(new Uri(STEAM_COMMUNITY)).Cast<Cookie>();
                foreach(var cookie in responseCookies)
                {
                    Console.WriteLine("Name {0}, {1}", cookie.Name, cookie.Value);
                }
                Console.WriteLine("Successfully logged in.");
                //SendCookies
            }
            else
            {
                Console.WriteLine("Couldn't login...");
                Console.WriteLine(result);
            }
        }
        private string EncryptPassword(RsaParameters rsaParam)
        {
            // Convert the public keys to BigIntegers
            var modulus = CreateBigInteger(rsaParam.Modulus);
            var exponent = CreateBigInteger(rsaParam.Exponent);
            // (modulus.ToByteArray().Length - 1) * 8
            //modulus has 256 bytes multiplied by 8 bits equals 2048
            var encryptedNumber = Pkcs1Pad2(rsaParam.Password, (2048 + 7) >> 3);
            // And now, the RSA encryption
            encryptedNumber = BigInteger.ModPow(encryptedNumber, exponent, modulus);
            
            //Reverse number and convert to base64
            var encryptedString = Convert.ToBase64String(encryptedNumber.ToByteArray().Reverse().ToArray());
            return encryptedString;
        }
        public static BigInteger Pkcs1Pad2(string data, int keySize)
        {
            if (keySize < data.Length + 11)
                return new BigInteger();
            var buffer = new byte[256];
            var i = data.Length - 1;
            while (i >= 0 && keySize > 0)
            {
                buffer[--keySize] = (byte)data[i--];
            }
            // Padding, I think
            var random = new Random();
            buffer[--keySize] = 0;
            while (keySize > 2)
            {
                buffer[--keySize] = (byte)random.Next(1, 256);
                //buffer[--keySize] = 5;
            }
            buffer[--keySize] = 2;
            buffer[--keySize] = 0;
            Array.Reverse(buffer);
            return new BigInteger(buffer);
        }
        public static BigInteger CreateBigInteger(string hex)
        {
            return BigInteger.Parse("00" + hex, NumberStyles.AllowHexSpecifier);
        }
    }
    public class LoginResult
    {
        public bool success;
        public bool emailauth_needed;
        public bool captcha_needed;
        public string message;
        public string captcha_gid;
        public string emailsteamid;
    }
    public class RsaParameters
    {
        public string Exponent;
        public string Modulus;
        public string Password;
    }
    public class RsaKey
    {
        public bool success;
        public string publickey_mod;
        public string publickey_exp;
        public string timestamp;
    }
