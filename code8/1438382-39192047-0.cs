        //Convert JSON Result
        var x509Metadata = JObject.Parse(jsonResult)
                            .Children()
                            .Cast<JProperty>()
                            .Select(i => new x509Metadata(i.Path, i.Value.ToString()));
        //Extract IssuerSigningKeys
        var issuerSigningKeys = x509Metadata.Select(s => s.X509SecurityKey);
        //Setup JwtTokenHandler 
        var handler = new JwtSecurityTokenHandler();
        SecurityToken token;
        handler.ValidateToken(user.FirebaseToken, new TokenValidationParameters
        {
            IssuerSigningKeys = issuerSigningKeys,
            ValidAudience = "myApp",
            ValidIssuer = "https://securetoken.google.com/myApp",
            IssuerSigningKeyResolver = (arbitrarily, declaring, these, parameters) => issuerSigningKeys
        }, out token);
    public class x509Metadata
    {
        public string KID { get; set; }
        public string Certificate { get; set; }
        public X509SecurityKey X509SecurityKey { get; set; }
        public x509Metadata(string kid, string certificate)
        {
            KID = kid;
            Certificate = certificate;
            X509SecurityKey = BuildSecurityKey(Certificate);
        }
        private X509SecurityKey BuildSecurityKey(string certificate)
        {
            //Remove : -----BEGIN CERTIFICATE----- & -----END CERTIFICATE-----
            var lines = certificate.Split('\n');
            var selectedLines = lines.Skip(1).Take(lines.Length - 3);
            var key = string.Join(Environment.NewLine, selectedLines);
            return new X509SecurityKey(new X509Certificate2(Convert.FromBase64String(key)));
        }
    }
