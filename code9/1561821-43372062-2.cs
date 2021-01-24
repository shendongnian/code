    if (eventresponse.IsSuccessStatusCode)
    {
        using (Stream stream = await eventresponse.Content.ReadAsStreamAsync())
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                var responseString = reader.ReadToEnd();
            }
        }
    }
