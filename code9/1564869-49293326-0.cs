    public YourResultBase Login(string username, string password)
            {
                var client = new RestClient("apiUrl");
                var request = new RestRequest(Method.GET)
                {
                    OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; }
                };
                request.AddHeader("Cache-Control", "no-cache");
                IRestResponse<YourResultBase> response = client.Execute<YourResultBase>(request);
                var result = response.Data;
                return result;
            }
