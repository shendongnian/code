    public void StoreInDictionary(string[] file, Dictionary<string, string> dictionary)
    {
        foreach (var line in file)
        {
            var cleansedLine = Regex.Replace(line, @"\s+", "");
            var commaIndex = cleansedLine.IndexOf(',');
            string valueOne = String.Empty;
            string valueTwo = String.Empty;
            if (commaIndex > 0)
            {
                valueOne = cleansedLine.Substring(0, commaIndex + 1);
                valueTwo = !String.IsNullOrWhiteSpace(cleansedLine.Substring(commaIndex + 1)) ? 
                            cleansedLine.Substring(commaIndex + 1) : 
                            String.Empty;
            }
            if (!dictionary.ContainsKey(valueOne))
            {
                dictionary.Add(valueOne, valueTwo);
            }
        }
    }
