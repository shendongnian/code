    ResponseDto response1 = null;
    SecondResponseDto response2 = null;
    XElement root = null;
    using (var response = (HttpWebResponse)request.GetResponse())
    {
        if (response.StatusCode == HttpStatusCode.OK)
        {
            using (var responseStream = response.GetResponseStream())
            using (var reader = JsonReaderWriterFactory.CreateJsonReader(responseStream, XmlDictionaryReaderQuotas.Max))
            {
                root = XElement.Load(reader);
            }
        }
    }
    // Replace the Where queries below with something appropriate to your actual JSON.
    if (root != null && root.Elements().Where(e => e.Name.LocalName == "data").Any())
    {
        var serializer = new DataContractJsonSerializer(typeof(ResponseDto));
        response1 = (ResponseDto)serializer.ReadObject(root.CreateReader());
    }
    else if (root != null && root.Elements().Where(e => e.Name.LocalName == "results").Any())
    {
        var serializer = new DataContractJsonSerializer(typeof(SecondResponseDto));
        response2 = (SecondResponseDto)serializer.ReadObject(root.CreateReader());
    }
