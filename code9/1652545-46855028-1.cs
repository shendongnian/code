        try
        {
            var jo = JObject.Parse(jsonString);
            Contract.Assert(!string.IsNullOrEmpty(jo["root"]["prop1"].ToString()));
            Contract.Assert(!string.IsNullOrEmpty(jo["root"]["prop2"].ToString()));
        }
        catch (JsonReaderException) { }
        catch (JsonSerializationException) { }
