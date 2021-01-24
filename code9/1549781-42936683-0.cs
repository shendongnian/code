    Stream stream = resp.GetResponseStream();
    using (StreamReader reader = new StreamReader(stream))
    {
        Console.WriteLine(reader.ReadToEnd());
    
        stream.Position = 0; //Reset position pointer
        reader.DiscardBufferedData();
    
        postResponse = JsonConvert.DeserializeObject<PostResponse>(reader.ReadToEnd());
    }
