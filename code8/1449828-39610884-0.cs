     private login_user LoginAsync(string username,string password)
        {
            try
            {
                RestClient client = new RestClient(base_url);   
                var request = new RestRequest("login", Method.GET);
                request.AddHeader("Content-Type", "Application/JSON");
                
                client.Authenticator = new HttpBasicAuthenticator(username, password);
                var restResponse = client.Execute(request);
                var content = restResponse.Content;
                string context_modifytoken = content.ToString().Replace("X-CSRF-Token", "X_CSRF_Token");
                var current_login_user = JsonConvert.DeserializeObject<login_user>(context_modifytoken);
                current_login_user.data.session_name = restResponse.Cookies[0].Name;
                current_login_user.data.session_id = restResponse.Cookies[0].Value;
                
                return current_login_user;
            }
            catch (HttpRequestException ex) { throw ex; }               
            
        }
