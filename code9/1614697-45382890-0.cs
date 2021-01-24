            public async Task<string> GetData_BodyMeasures()
        {
            string rawdata = "";
            try
            {
                string random = GetRandomString();
                string timestamp = GetTimestamp();
                string baseSignature = GetDataSignature_BodyMeasure(random, timestamp);
                string hashSignature = ComputeHash(baseSignature, CONSUMER_SECRET, ACCESS_OAUTH_TOKEN_SECRET);
                string codeSignature = UrlEncode(hashSignature);
                string requestUrl = GetData_BodyMeasure_Url(codeSignature, random, timestamp);
                HttpResponseMessage response = await client.GetAsync(requestUrl);
                string responseBodyAsText = await response.Content.ReadAsStringAsync();
                rawdata = responseBodyAsText;
            }
            catch (Exception ex)
            {
            }
            return rawdata;
        }
        private string GetDataSignature_BodyMeasure(string random, string timestamp)
        {
            var urlDict = new SortedDictionary<string, string>
            {
                { "oauth_consumer_key", CONSUMER_KEY},
                { "oauth_nonce", random},
                { "oauth_signature_method", SIGNATURE_METHOD},
                { "oauth_timestamp", timestamp},
                { "oauth_token", ACCESS_OAUTH_TOKEN },
                { "oauth_version", AUTH_VERSION},
                { "userid", USER_ID }
            };
            StringBuilder sb = new StringBuilder();
            sb.Append("GET&" + UrlEncode(BASE_URL_REQUEST_BODY_MEASURE) + "&action%3Dgetmeas");
            int count = 0;
            foreach (var urlItem in urlDict)
            {
                count++;
                if (count >= 1) sb.Append(UrlEncode("&"));
                sb.Append(UrlEncode(urlItem.Key + "=" + urlItem.Value));
            }
            return sb.ToString();
        }
        private string GetData_BodyMeasure_Url(string signature, string random, string timestamp)
        {
            var urlDict = new SortedDictionary<string, string>
            {
                { "action", "getmeas"},
                { "oauth_consumer_key", CONSUMER_KEY},
                { "oauth_nonce", random},
                { "oauth_signature", signature },
                { "oauth_signature_method", UrlEncode(SIGNATURE_METHOD)},
                { "oauth_timestamp", timestamp},
                { "oauth_token", ACCESS_OAUTH_TOKEN },
                { "oauth_version", AUTH_VERSION},
                { "userid", USER_ID }
            };
            StringBuilder sb = new StringBuilder();
            sb.Append(BASE_URL_REQUEST_BODY_MEASURE + "?");
            int count = 0;
            foreach (var urlItem in urlDict)
            {
                count++;
                if (count >= 1) sb.Append("&");
                sb.Append(urlItem.Key + "=" + urlItem.Value);
            }
            return sb.ToString();
        }
