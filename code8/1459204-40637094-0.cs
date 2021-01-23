            public HttpClient GetHttpClient(string baseAdress)
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(baseAdress);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string token;
                if (Session["access_token"] != null)
                { 
                    var jwthandler = new JwtSecurityTokenHandler();
                    var jwttoken = jwthandler.ReadToken(Session["access_token"] as string);
                    var expDate = jwttoken.ValidTo;
                    if (expDate < DateTime.UtcNow.AddMinutes(1))
                        token = GetAccessToken().Result;
                    else
                        token = Session["access_token"] as string;
                }
                else
                {
                    token = GetAccessToken().Result;
    
                }
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                Session["access_token"] = token;
                return client;
            }
