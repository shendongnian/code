    public void SaveMetaData(string fileName, string container, string key, string value)
    {
        var blob = GetBlobReference(fileName, container);
        blob.FetchAttributes();
        if (blob.Metadata.ContainsKey(key))
        {
            blob.Metadata[key] = value;
        }
        else
            blob.Metadata.Add(key, value);
        blob.SetMetadata();
    }
