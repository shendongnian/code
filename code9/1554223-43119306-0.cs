    using (StreamReader sr = new StreamReader(responseStream))
    {
        using (JsonTextReader jr = new JsonTextReader(sr))
        {
            while (jr.Read())
                if (jr.TokenType == JsonToken.StartArray)
                    break;
            jr.Read();
            JsonSerializer Jser = new JsonSerializer();
            while (!sr.EndOfStream && jr.TokenType != JsonToken.EndArray)
            {
                if(jr.TokenType == JsonToken.StartObject)
                {
                    T tobj = Jser.Deserialize<T>(jr);
                    objList.Add(tobj);
                }
                //consume the EndObject tag
                if (jr.TokenType == JsonToken.EndObject)
                    jr.Read();
                //Deliberately slow down the process, On purpose, otherwise we will overrun the stream itself and throw an error
                Thread.Sleep(1); //<=== VERY IMPORTANT LINE
            }
        }
    }
