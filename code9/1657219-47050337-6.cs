    public string addition(int firstNumber, int secondNumber)
            {
                try
                {
                    var endpoint = string.Format("addition/{0}/{1}", firstNumber, secondNumber);
                    HttpResponseMessage response = client.GetAsync(endpoint).Result;
                    //This will check whether or not the response was executed successfully(status code 200ish or not 
                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        throw new Exception($"The server responded with a bad request of type: {response.StatusCode}");
                    }
                }
                catch (Exception e)
                {
                    HttpContext.Current.Server.Transfer("ErrorPage.html");
                }
                return null;
            }
