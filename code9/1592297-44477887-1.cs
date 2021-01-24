    Dictionary<string, List<string>> ReadDictionaryFromJson(string inputfilename)
    {
        using (var inputFileStream = File.OpenRead(inputfilename))
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Dictionary<string, List<string>>));
            return (Dictionary<string, List<string>>)js.ReadObject(inputFileStream);
        }
    }
