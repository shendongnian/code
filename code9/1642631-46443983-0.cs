    public string CreateToken(string thumbprint, string iss, string sub, string aud, int lifetime)
        {
            var lifeDuration = new Lifetime(DateTime.Now, DateTime.Now.AddMinutes(lifetime));
            var cert = this.FindCertificate(thumbprint);
            var signingCredentials = new SigningCredentials(new X509SecurityKey(cert), SecurityAlgorithms.RsaSha256Signature);
            JwtHeader header = new JwtHeader(signingCredentials);
            header.Clear();
            header.Add("alg", "RS256");
            header.Add("typ", "JWT");
            JwtPayload payload = new JwtPayload(
                iss, 
                aud, 
                new List<Claim>()
                {
                    new Claim("sub", sub),
                    new Claim("jti", Guid.NewGuid().ToString())
                }, 
                null, 
                lifeDuration.Expires);
            var jwt = new JwtSecurityToken(header, payload);
            var encoded = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encoded;
        }
