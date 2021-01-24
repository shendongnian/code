    public class APIKeyHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var formData = await request.Content.ReadAsStringAsync();
            request.Content = new StringContent(ModifyYourFormData(formData));
            request.RequestUri = new Uri(ModifyYourURI(request.RequestUri.ToString()), UriKind.Absolute);
            return await base.SendAsync(request, cancellationToken);
        }
        public string ModifyYourFormData(string formData)
        {
            //Add your logic here
            return "";
        }
        public string ModifyYourURI(string formData)
        {
            //Add your logic here
            return "";
        }        
    }
