    HttpResponseMessage responseMessage;
            try
            {
                responseMessage = await client.GetAsync(url);
            }
            catch (Exception ex)
            {
                throw ex;
            }
