    private static void CallWebAPIUsingWebClient(string dataString, TokenResponse token, string middlewareUrl)
            {            
                using (WebClient client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers[HttpRequestHeader.Accept] = "application/json";
                    client.Headers[HttpRequestHeader.Authorization] = token.TokenType.ToLowerInvariant() + " " + token.AccessToken;
                    client.Headers.Add("Username", "WebClient");
                    client.UploadString(middlewareUrl, "PUT", dataString);
                }
            }
