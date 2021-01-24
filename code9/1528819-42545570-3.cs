                                if (tokenTemplate.PrimaryVerificationKey.GetType() == typeof(SymmetricVerificationKey))
                                {
                                    InMemorySymmetricSecurityKey tokenSigningKey = new InMemorySymmetricSecurityKey((tokenTemplate.PrimaryVerificationKey as SymmetricVerificationKey).KeyValue);
                                    signingcredentials = new SigningCredentials(tokenSigningKey, SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);
                                }
                                else if (tokenTemplate.PrimaryVerificationKey.GetType() == typeof(X509CertTokenVerificationKey))
                                {
                                    if (signingcredentials == null)
                                    {
                                        X509Certificate2 cert = DynamicEncryption.GetCertificateFromFile(true).Certificate;
                                        if (cert != null) signingcredentials = new X509SigningCredentials(cert);
                                    }
                                }
                                JwtSecurityToken token = new JwtSecurityToken(issuer: tokenTemplate.Issuer, audience: tokenTemplate.Audience, notBefore: DateTime.Now.AddMinutes(-5), expires: DateTime.Now.AddMinutes(Properties.Settings.Default.DefaultTokenDuration), signingCredentials: signingcredentials, claims: myclaims);
                                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                                string token = handler.WriteToken(token);
