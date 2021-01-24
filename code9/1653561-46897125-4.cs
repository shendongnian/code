    public string UpdateRequest(string uid, string field, string value)
            {
                try
                { 
                    string url = _EndPoint + "?_action=patch&_queryId=for-userName&uid=" + uid;
                    var client = new RestClient(url);
                    var request = new RestRequest(Method.POST);
                    string username = "openidm-admin";
                    string password = "openidm-admin";
                    string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + password));
                    string Update = BuildUpdate(field, value);
    
                    if (Update != null)
                    {
                        request.AddHeader("Authorization", "Basic " + svcCredentials);
                        request.AddHeader("content-type", "application/json");
                        request.AddParameter("application/json", Update, ParameterType.RequestBody);
                        IRestResponse response = client.Execute(request);
    
                        return response.Content.ToString();
                    }
                    else
                    {
                        //Error
                        return "Error";
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            } 
