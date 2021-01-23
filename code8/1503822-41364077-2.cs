        public static async Task<String> GetAuthProviderParam(String iAuthMeURL,
            String iXZumoAUth,
            String iParamKey)
        {
            using (HttpClient pHCtClient = new HttpClient())
            {
                pHCtClient.DefaultRequestHeaders.Add("x-zumo-auth", iXZumoAUth);
                String pStrResponse = await pHCtClient.GetStringAsync(iAuthMeURL);
                JObject pJOtResponse = JObject.Parse(pStrResponse.Trim(new Char[] { '[', ']' }));
                if(pJOtResponse[iParamKey] != null)
                {
                    return (pJOtResponse[iParamKey].Value<String>());
                }
                else
                {
                    throw new KeyNotFoundException(String.Format("A parameter with the key '{0}' was not found.", iParamKey));
                }
            }
        }
