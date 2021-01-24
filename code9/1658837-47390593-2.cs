    private List<SecurityKey> GetSecurityKeys(JsonWebKeySet jsonWebKeySet)
    {
          var keys = new List<SecurityKey>();
          foreach (var key in jsonWebKeySet.Keys)
          {
              if (key.Kty == OpenIdConnectConstants.Rsa)
              {
                 if (key.X5C != null && key.X5C.Length > 0)
                 {
                    string certificateString = key.X5C[0];
                    var certificate = new X509Certificate2(Convert.FromBase64String(certificateString));
                    var x509SecurityKey = new X509SecurityKey(certificate)
                                          {
                                              KeyId = key.Kid
                                          };
                     keys.Add(x509SecurityKey);
                  }
                  else if (!string.IsNullOrWhiteSpace(key.E) && !string.IsNullOrWhiteSpace(key.N))
                  {
                      byte[] exponent = Base64Url.Decode(key.E);
                      byte[] modulus = Base64Url.Decode(key.N);
                      var rsaParameters = new RSAParameters
                                          {
                                              Exponent = exponent,
                                              Modulus = modulus
                                          };
                      var rsaSecurityKey = new RsaSecurityKey(rsaParameters)
                                           {
                                               KeyId = key.Kid
                                           };
                      keys.Add(rsaSecurityKey);
                  }
                  else
                  {
                      throw new PlatformAuthException("JWK data is missing in token validation");
                  }
              }
              else
              {
                  throw new NotImplementedException("Only RSA key type is implemented for token validation");
              }
          }
          return keys;
      }
