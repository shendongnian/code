        private string GenerateToken1()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var certificate = new X509Certificate2(@"C:\Users\myname\my-cert.pfx", "mypassword");
            var securityKey = new X509SecurityKey(certificate);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(),
                Issuer = "Self",
                IssuedAt = DateTime.Now,
                Audience = "Others",
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = new SigningCredentials(
                    securityKey,
                    SecurityAlgorithms.RsaSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
