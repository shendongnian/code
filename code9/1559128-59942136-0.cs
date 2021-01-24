    public enum PasswordOption
    {
        SendPlain = 0,
        SendHashed = 1,
        SendNone = 2
    }
    
    public class UsernameToken
    {
        private string Username;
        private string Password;
        private PasswordOption PwdOption;
        public UsernameToken(string username, string password, PasswordOption option)
        {
            Username = username;
            Password = password;
            PwdOption = option;
        }
        public XmlElement GetXml(XmlDocument xmlDoc)
        {
            string wsse = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";
            string wsu = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd";
            XmlDocument doc = xmlDoc;
            //XmlElement securityEl = doc.CreateElement("Security", wsse);
            XmlElement usernameTokenEl = doc.CreateElement("wsse", "UsernameToken", wsse);
            XmlAttribute a = doc.CreateAttribute("wsu", "Id", wsu);
            usernameTokenEl.SetAttribute("xmlns:wsse", wsse);
            usernameTokenEl.SetAttribute("xmlns:wsu", wsu);
            a.InnerText = "SecurityToken-" + Guid.NewGuid().ToString();
            usernameTokenEl.Attributes.Append(a);
            //Username
            XmlElement usernameEl = doc.CreateElement("wsse:Username", wsse);
            usernameEl.InnerText = Username;
            usernameTokenEl.AppendChild(usernameEl);
            //Password
            XmlElement pwdEl = doc.CreateElement("wsse:Password", wsse);
            switch (PwdOption)
                {
                case PasswordOption.SendHashed:
                    //Nonce+Create+Password
                    pwdEl.SetAttribute("Type", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordDigest");
                    string created = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
                    byte[] nonce = GenerateNonce(16);
                    byte[] pwdBytes = Encoding.ASCII.GetBytes(Password);
                    byte[] createdBytes = Encoding.ASCII.GetBytes(created);
                    byte[] pwdDigest = new byte[nonce.Length + pwdBytes.Length + createdBytes.Length];
                    Array.Copy(nonce, pwdDigest, nonce.Length);
                    Array.Copy(createdBytes, 0, pwdDigest, nonce.Length, createdBytes.Length);
                    Array.Copy(pwdBytes, 0, pwdDigest, nonce.Length + createdBytes.Length, pwdBytes.Length);
                    pwdEl.InnerText = ToBase64(SHA1Hash(pwdDigest));
                    usernameTokenEl.AppendChild(pwdEl);
                    //Nonce
                    XmlElement nonceEl = doc.CreateElement("wsse:Nonce", wsse);
                    nonceEl.SetAttribute("EncodingType", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary");
                    nonceEl.InnerText = ToBase64(nonce);
                    usernameTokenEl.AppendChild(nonceEl);
                    //Created
                    XmlElement createdEl = doc.CreateElement("wsu:Created", wsu);
                    createdEl.InnerText = created;
                    usernameTokenEl.AppendChild(createdEl);
                    break;
                case PasswordOption.SendNone:
                    pwdEl.SetAttribute("Type", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText");
                    pwdEl.InnerText = "";
                    usernameTokenEl.AppendChild(pwdEl);
                    break;
                case PasswordOption.SendPlain:
                    pwdEl.SetAttribute("Type", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText");
                    pwdEl.InnerText = Password;
                    usernameTokenEl.AppendChild(pwdEl);
                    break;
            }
            return usernameTokenEl;
        }
        private byte[] GenerateNonce(int bytes)
        {
            byte[] output = new byte[bytes];
            Random r = new Random(DateTime.Now.Millisecond);
            r.NextBytes(output);
            return output;
        }
        private static byte[] SHA1Hash(byte[] input)
        {
            SHA1CryptoServiceProvider sha1Hasher = new SHA1CryptoServiceProvider();
            return sha1Hasher.ComputeHash(input);
        }
       
        private static string ToBase64(byte[] input)
        {
            return Convert.ToBase64String(input);
        }
    }
}
