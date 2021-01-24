    public HttpResponseMessage Index()
        {
            var configLoc = WebConfigurationManager.AppSettings["configLocation"];
            var path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), configLoc);
            var response = new HttpResponseMessage();
            response.Content = new StringContent(File.ReadAllText(path));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
            return response;
        }
