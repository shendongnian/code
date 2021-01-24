        private string GetSASToken(string resourceUri, string key, string keyName = null, uint hours = 24)
        {
            var expiry = Convert.ToString((int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds + 3600 * hours);
            string stringToSign = System.Net.WebUtility.UrlEncode(resourceUri) + "\n" + expiry;
            HMACSHA256 hmac = new HMACSHA256(Convert.FromBase64String(key));
            var signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
            var sasToken = keyName == null ?
                String.Format(CultureInfo.InvariantCulture, "SharedAccessSignature sr={0}&sig={1}&se={2}", System.Net.WebUtility.UrlEncode(resourceUri), System.Net.WebUtility.UrlEncode(signature), expiry) :
                String.Format(CultureInfo.InvariantCulture, "SharedAccessSignature sr={0}&sig={1}&se={2}&skn={3}", System.Net.WebUtility.UrlEncode(resourceUri), System.Net.WebUtility.UrlEncode(signature), expiry, keyName);
            return sasToken;
        }
