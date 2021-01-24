    public class APIKeyHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var formData = await request.Content.ReadAsFormDataAsync();
            if (request.Method.Method.Equals("POST"))
            {
                request.Content = new FormUrlEncodedContent(ModifyYourFormData(formData, request));
            }
            request.RequestUri = new Uri(ModifyYourURI(request.RequestUri.ToString(), request), UriKind.Absolute);
            return await base.SendAsync(request, cancellationToken);
        }
        public IEnumerable<KeyValuePair<string, string>> ModifyYourFormData(NameValueCollection source, HttpRequestMessage request)
        {
            //Add your logic here
            string Authorized = "";
            try
            {
                Authorized = request.Headers.GetValues("AuthorizedKey").FirstOrDefault();
            }
            catch (Exception ex)
            {
                
            }
            List<KeyValuePair<string, string>> formData;
            formData = source.AllKeys.SelectMany(
                source.GetValues,
                (k, v) => new KeyValuePair<string, string>(k, v)).ToList();
            if (!string.IsNullOrEmpty(Authorized))
            {
                formData.Insert(0, new KeyValuePair<string, string>("AuthorizedKey", Authorized)); 
            }
            return formData;
        }
        public string ModifyYourURI(string uri, HttpRequestMessage request)
        {
            //Add your logic here
            string Authorized = "";
            try
            {
                Authorized = request.Headers.GetValues("AuthorizedKey").FirstOrDefault();
            }
            catch (Exception ex)
            {
            }
            
            if (!string.IsNullOrEmpty(Authorized))
            {
                return uri + "?AuthorizedKey="+ Authorized;
            }
            else
            {
                return uri;
            }
        }
    }
