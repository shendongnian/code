    public static NameValueCollection Convert(this FormDataCollection formDataCollection)
    {
        IEnumerator<KeyValuePair<string, string>> pairs = formDataCollection.GetEnumerator();
    
        NameValueCollection collection = new NameValueCollection();
    
        while (pairs.MoveNext())
        {
            KeyValuePair<string, string> pair = pairs.Current;
            collection.Add(pair.Key, pair.Value);
        }
    
        return collection;
    }
