      public User ReadSamlResponse(string samlResponse, string profileName, bool isSAMLProfile = true)
        {
            User User = new User();
            var DecodedSamlResponse = Convert.FromBase64String(samlResponse);
            string ResponseDecoded = coding.UTF8.GetString(DecodedSamlResponse);
            
                Saml2SecurityToken Token = _samlAuthenticationService.DeserializeSAMLResponse(ResponseDecoded);
                if ()// apply condition here if you need to validate signature
                {
                    if (!_samlAuthenticationService.ValidateSamlToken(ResponseDecoded, AuthenticationConnector, isSAMLProfile))
                        throw new Exception("Signature is invalid");
                }
                User = GetUserFromToken(Token);
                return User;
            }
