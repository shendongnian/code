    class Program
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText(@"c:\temp\job3.json");
            var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            RecurseDeserialize(result);
        }
    
        private static void RecurseDeserialize(Dictionary<string, object> result)
        {
            //Iterate throgh key/value pairs
            foreach (var keyValuePair in result.ToArray())
            {
                //Check to see if Newtonsoft thinks this is a JArray
                var jarray = keyValuePair.Value as JArray;
    
                if (jarray != null)
                {
                    //We have a JArray
    
                    //Convert JArray back to json and deserialize to a list of dictionaries
                    var dictionaries = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jarray.ToString()); 
    
                    //Set the result as the dictionary
                    result[keyValuePair.Key] = dictionaries;
    
                    //Iterate throught the dictionaries
                    foreach (var dictionary in dictionaries)
                    {
                        //Recurse
                        RecurseDeserialize(dictionary);
                    }
                }
            }
        }
    }
