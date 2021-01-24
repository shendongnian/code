     internal async static Task<Byte[]> GetFile(string fileName) 
    {
            Byte[] returnedTask = null;
            using (var client = new HttpClient())
            {
		        UriBuilder uriBuilder = new UriBuilder(string.Format(@"{0}{1}", <Web api URI>, "/Files/GetFile"));
                if (!string.IsNullOrEmpty(fileName))
                {
                    uriBuilder.Query = string.Format("fileName={0}", fileName);
                }
                client.BaseAddress = new Uri(uriBuilder.ToString());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/pdf"));
                returnedTask = await client.GetByteArrayAsync(client.BaseAddress);
            }
            return returnedTask;
        }
