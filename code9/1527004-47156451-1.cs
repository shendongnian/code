    public static class DictionaryCsvExtentions
    {
        public static dynamic BuildCsvObject(this Dictionary<string, object> document)
        {
            dynamic csvObj = new ExpandoObject();
            foreach (var p in document)
            {
                AddProperty(csvObj, p.Key, p.Value);
            }
            return csvObj;
        }
        private static void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
        {
            var expandoDict = expando as IDictionary<string, object>;
            if (expandoDict.ContainsKey(propertyName))
            {
                expandoDict[propertyName] = propertyValue;
            }
            else
            {
                expandoDict.Add(propertyName, propertyValue);
            }
        }
    }
