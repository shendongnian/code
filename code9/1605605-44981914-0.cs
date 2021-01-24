            string Page = "https://stackoverflow.com/questions/44980231/";
            HttpClientHandler ClientHandler = new HttpClientHandler();
            ClientHandler.AllowAutoRedirect = false;
            HttpClient client = new HttpClient(ClientHandler);
            HttpResponseMessage response = await client.GetAsync(Page);
            try
            {
                string location = response.Headers.GetValues("Location").FirstOrDefault();
                if (!Uri.IsWellFormedUriString(location, UriKind.Absolute))
                {
                    Uri PageUri = new Uri(Page);
                    location = PageUri.Scheme + "://" + PageUri.Host + location;
                }
                MessageBox.Show(location);
            }
            catch
            {
                MessageBox.Show("No redirect!");
            }
