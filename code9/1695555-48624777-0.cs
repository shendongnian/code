    using (var ms = new MemoryStream())
    {
        //Generazione del Json
        using (var textWriter = new StreamWriter(ms, System.Text.Encoding.UTF8))
        {
            using (var jsonWriter = new JsonTextWriter(textWriter))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jsonWriter, objectToEncode, objectToEncode.GetType());                    
            }
        }
        jsonResult = ms.ToArray();
    }
    using (var msResult = new MemoryStream())
    {
        using (var encodingStream = GenerateEncodingStream(msResult))
        {
            encodingStream.Write(jsonResult, 0, Convert.ToInt32(jsonResult.Length));                
        }
        return msResult.ToArray();
    }
