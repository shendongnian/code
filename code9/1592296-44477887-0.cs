    void WriteDictionaryAsJson(Dictionary<string, List<string>> myDict, string outputfilename)
    {
        using (var outputFileStream = File.OpenWrite(outputfilename))
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Dictionary<string, List<string>>));
            js.WriteObject(outputFileStream, myDict);
        }
    }
