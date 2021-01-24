    public string Connect()
            {
                var client = new RestClient();
                var request = new RestRequest("myURL.com", Method.GET);
                request.AddParameter("Authorization", "Bearer OEMwNjI2ODQtMTc3OC00RkIxLTgyN0YtNzEzRkE5NzY3RTc3");
                var response = client.Execute(request);
                return response.Content;
            }
