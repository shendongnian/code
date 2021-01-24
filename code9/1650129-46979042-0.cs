      public static async Task<string> postdataAsync(Uri posturl, Dictionary<string, string> pairs)
        {
            string response = "";
            try
            {
                var filter = new HttpBaseProtocolFilter();
                filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Expired);
                filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Untrusted);
                filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.InvalidName);
                HttpClient httpClient = new HttpClient(filter);
                Windows.Web.Http.HttpFormUrlEncodedContent formContent = new Windows.Web.Http.HttpFormUrlEncodedContent(pairs);
                HttpResponseMessage httpresponse = await httpClient.PostAsync(posturl, formContent);
                response = await httpresponse.Content.ReadAsStringAsync();
            }
            catch
            {
                return null;
            }
            return response;
        }
