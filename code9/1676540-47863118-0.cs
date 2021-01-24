            try
            {
                var endpoint = string.Format("addition/{0}/{1}", firstNumber, secondNumber);
                var response = await client.GetAsync(endpoint);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                if (e.InnerException.Message == "The method or operation is not implemented")
                {
                    //Do something
                }
            }
