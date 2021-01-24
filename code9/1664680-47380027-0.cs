            const string consumerKey = "";
            const string consumerSecret = "";
            const string tokenSecret = "";
            const string tokenValue = "";
            const string url = "https://api.bricklink.com/api/store/v1/items/part/3001";
            string Escape(string s)
            {
                // https://stackoverflow.com/questions/846487/how-to-get-uri-escapedatastring-to-comply-with-rfc-3986
                var charsToEscape = new[] {"!", "*", "'", "(", ")"};
                var escaped = new StringBuilder(Uri.EscapeDataString(s));
                foreach (var t in charsToEscape)
                {
                    escaped.Replace(t, Uri.HexEscape(t[0]));
                }
                return escaped.ToString();
            }
            var httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            var timeStamp = ((int) (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds).ToString();
            var nonce = Convert.ToBase64String(Encoding.UTF8.GetBytes(timeStamp));
            var signatureBaseString = Escape(httpWebRequest.Method.ToUpper()) + "&";
            signatureBaseString += EscapeUriDataStringRfc3986(url.ToLower()) + "&";
            signatureBaseString += EscapeUriDataStringRfc3986(
                "oauth_consumer_key=" + EscapeUriDataStringRfc3986(consumerKey) + "&" +
                "oauth_nonce=" + EscapeUriDataStringRfc3986(nonce) + "&" +
                "oauth_signature_method=" + EscapeUriDataStringRfc3986("HMAC-SHA1") + "&" +
                "oauth_timestamp=" + EscapeUriDataStringRfc3986(timeStamp) + "&" +
                "oauth_token=" + EscapeUriDataStringRfc3986(tokenValue) + "&" +
                "oauth_version=" + EscapeUriDataStringRfc3986("1.0"));
            Console.WriteLine(@"signatureBaseString: " + signatureBaseString);
            var key = EscapeUriDataStringRfc3986(consumerSecret) + "&" + EscapeUriDataStringRfc3986(tokenSecret);
            Console.WriteLine(@"key: " + key);
            var signatureEncoding = new ASCIIEncoding();
            var keyBytes = signatureEncoding.GetBytes(key);
            var signatureBaseBytes = signatureEncoding.GetBytes(signatureBaseString);
            string signatureString;
            using (var hmacsha1 = new HMACSHA1(keyBytes))
            {
                var hashBytes = hmacsha1.ComputeHash(signatureBaseBytes);
                signatureString = Convert.ToBase64String(hashBytes);
            }
            signatureString = EscapeUriDataStringRfc3986(signatureString);
            Console.WriteLine(@"signatureString: " + signatureString);
            string SimpleQuote(string s) => '"' + s + '"';
            var header =
                "OAuth realm=" + SimpleQuote("") + "," +
                "oauth_consumer_key=" + SimpleQuote(consumerKey) + "," +
                "oauth_nonce=" + SimpleQuote(nonce) + "," +
                "oauth_signature_method=" + SimpleQuote("HMAC-SHA1") + "," +
                "oauth_timestamp=" + SimpleQuote(timeStamp) + "," +
                "oauth_token=" + SimpleQuote(tokenValue) + "," +
                "oauth_version=" + SimpleQuote("1.0") + "," +
                "oauth_signature= " + SimpleQuote(signatureString);
            Console.WriteLine(@"header: " + header);
            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, header);
            var response = httpWebRequest.GetResponse();
            var characterSet = ((HttpWebResponse) response).CharacterSet;
            var responseEncoding = characterSet == ""
                ? Encoding.UTF8
                : Encoding.GetEncoding(characterSet ?? "utf-8");
            var responsestream = response.GetResponseStream();
            if (responsestream == null)
            {
                throw new ArgumentNullException(nameof(characterSet));
            }
            using (responsestream)
            {
                var reader = new StreamReader(responsestream, responseEncoding);
                var result = reader.ReadToEnd();
                Console.WriteLine(@"result: " + result);
            }
