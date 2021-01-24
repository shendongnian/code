    public static Dictionary<string, string> CustomConvert(string filename)
        {
            if (!File.Exists(filename))
                throw new InvalidOperationException();
            string text = File.ReadAllText(filename);
            var result = new Dictionary<string, string>();
            //extract every pair like:{ "key1", "value1"}
            Regex regex = new Regex(@"{[^{}]*}");
            foreach (Match match in regex.Matches(text))
            {
                //convert to JSON
                var json = match.Value.Replace(",", ":");
                var singleDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                result.Add(singleDict.First().Key, singleDict.First().Value);
            }
            return result;
        }
