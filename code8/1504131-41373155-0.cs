    public T Json2Object<T>(string json, Encoding encoding) {
        T result;
        DataContractJsonSerializer ser = new DataContractJsonSerializer( typeof( T ) );
        using ( Stream s = new MemoryStream( ( encoding ?? Encoding.UTF8 ).GetBytes( json ?? "" ) ) ) {
            result = (T)ser.ReadObject( s );
        }
        return result;
    }
