    void ConvertThenCallback(HTTPResponse response, bool isGet, IJsonSerializer<T> serializer = null)
    {
        try 
        {
            if(serializer == null)
            {
                serializer = new DefaultJsonSerializer<T>();
            }
            j = serializer.Deserialize(response.DataAsText);
        } 
        catch (ArgumentException) 
        {
            /* Conversion problem */
            return;
        }
    }
