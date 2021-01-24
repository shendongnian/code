    public List<EnglishMonarch> GetData (string jsonData)
    {
        if (string.IsNullOrWhiteSpace (jsonData))
            return new List<EnglishMonarch> ();
        return JsonConvert.DeserializeObject<List<EnglishMonarch>> (jsonData);
    }
