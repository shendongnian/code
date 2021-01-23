    /// <summary>
        /// Method returns ECDSA signed JWT token format, from json header, json payload and privateKey (pure string extracted from *.p8 file - PKCS#8 format)
        /// </summary>
        /// <param name="privateKey">ECDSA256 key</param>
        /// <param name="header">JSON header, i.e. "{\"alg\":\"ES256\" ,\"kid\":\"1234567899"\"}"</param>
        /// <param name="payload">JSON payload, i.e.  {\"iss\":\"MMMMMMMMMM"\",\"iat\":"122222222229"}"</param>
        /// <returns>base64url encoded JWT token</returns>
        public static string SignES256(string privateKey, string header, string payload)
        {
            CngKey key = CngKey.Import(
                Convert.FromBase64String(privateKey), 
                CngKeyBlobFormat.Pkcs8PrivateBlob);
            using (ECDsaCng dsa = new ECDsaCng(key))
            {
                dsa.HashAlgorithm = CngAlgorithm.Sha256;
                var unsignedJwtData = 
                    Url.Base64urlEncode(Encoding.UTF8.GetBytes(header)) + "." + Url.Base64urlEncode(Encoding.UTF8.GetBytes(payload));
                var signature = 
                    dsa.SignData(Encoding.UTF8.GetBytes(unsignedJwtData));
                return unsignedJwtData + "." + Url.Base64urlEncode(signature);
            }
        }
