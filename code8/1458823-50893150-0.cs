     public async Task<ClaimsPrincipal> CreatePrincipleAsync()
        {
            AzureActiveDirectoryToken azureToken = Token.FromJsonString<AzureActiveDirectoryToken>();
            var allParts = azureToken.IdToken.Split(".");
            var header = allParts[0];
            var payload = allParts[1];
            var idToken = payload.ToBytesFromBase64URLString().ToAscii().FromJsonString<AzureActiveDirectoryIdToken>();
    
            allParts = azureToken.AccessToken.Split(".");
            header = allParts[0];
            payload = allParts[1];
            var signature = allParts[2];
            var accessToken = payload.ToBytesFromBase64URLString().ToAscii().FromJsonString<AzureActiveDirectoryAccessToken>();
    
            var accessTokenHeader = header.ToBytesFromBase64URLString().ToAscii().FromJsonString<AzureTokenHeader>();
            var isValid = await ValidateToken(accessTokenHeader.kid, header, payload, signature);
            if (!isValid)
            {
                throw new SecurityException("Token can not be validated");
            }
            var principal = await CreatePrincipalAsync(accessToken, idToken);
            return principal;
        }
    
       
    
        private async Task<bool> ValidateToken(string kid, string header, string payload, string signature)
        {
            string keysAsString = null;
            const string microsoftKeysUrl = "https://login.microsoftonline.com/common/discovery/keys";
    
            using (var client = new HttpClient())
            {
                keysAsString = await client.GetStringAsync(microsoftKeysUrl);
            }
            var azureKeys = keysAsString.FromJsonString<MicrosoftConfigurationKeys>();
            var signatureKeyIdentifier = azureKeys.Keys.FirstOrDefault(key => key.kid.Equals(kid));
            if (signatureKeyIdentifier.IsNotNull())
            {
                var signatureKey = signatureKeyIdentifier.x5c.First();
                var certificate = new X509Certificate2(signatureKey.ToBytesFromBase64URLString());
                var rsa = certificate.GetRSAPublicKey();
                var data = string.Format("{0}.{1}", header, payload).ToBytes();
    
                var isValidSignature = rsa.VerifyData(data, signature.ToBytesFromBase64URLString(), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                return isValidSignature;
            }
    
            return false;
        }
