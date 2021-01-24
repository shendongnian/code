    public async Task<string> addition(int firstNumber, int secondNumber)
        {
            try
            {
                var endpoint = string.Format("addition/{0}/{1}", firstNumber, secondNumber);
                HttpResponseMessage response = await client.GetAsync(endpoint);
                //This will check whether or not the response was executed successfully(status code 200ish or not
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception($"The server responded with a bad request of type: {response.StatusCode}");
                }             
            }
            catch (Exception e)
            {
                //ToDo in case the ErrorPage automatically displays the exception remove the message box if not find a way to pass the Exception to the error page
                MessageBox.Show(e.Message);
                HttpContext.Current.Server.Transfer("ErrorPage.html");
            }
            return null;
        }
