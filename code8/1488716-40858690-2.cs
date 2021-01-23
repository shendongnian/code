    //Deserialize the JSON stream
    using (StreamReader reader = new StreamReader(responseStream))
        {
            string r = reader.ReadToEnd();
            //Deserialize our JSON
            DataContractJsonSerializer sr = new DataContractJsonSerializer(typeof(RootObject));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(r));
            jsonResponse = (RootObject)sr.ReadObject(ms);
    }
