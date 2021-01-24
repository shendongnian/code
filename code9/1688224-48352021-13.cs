    ResponseDto response1;
    SecondResponseDto response2;
    var copyStream = new MemoryStream();
    using (var response = (HttpWebResponse)request.GetResponse())
    {
        if (response.StatusCode == HttpStatusCode.OK)
        {
            using (var responseStream = response.GetResponseStream())
            {
                responseStream.CopyTo(copyStream);
            }
        }
    }
    try
    {
        var serializer = new DataContractJsonSerializer(typeof(ResponseDto));
        copyStream.Position = 0L;
        response1 = (ResponseDto)serializer.ReadObject(copyStream);
    }
    catch (SerializationException)
    {
        response1 = null;
    }
    if (response1 != null)
        response2 = null;
    else
    {
        try
        {
            var otherResponseSerializer = new DataContractJsonSerializer(typeof(SecondResponseDto));
            copyStream.Position = 0L;
            response2 = (SecondResponseDto)otherResponseSerializer.ReadObject(copyStream);
        }
        catch (SerializationException)
        {
            response2 = null;
        }
    }
