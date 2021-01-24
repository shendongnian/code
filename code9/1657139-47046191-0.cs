        private static Dictionary<string, object> RecursiveDeserialize(string json)
        {
            var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            foreach (var pair in result.ToArray())
            {
                var jarray = pair.Value as JArray;
                if (jarray != null)
                {
                    result[pair.Key] = DeserializeJarray(jarray);
                }
            }
            return result;
        }
        private static List<Dictionary<string, object>> DeserializeJarray(JArray jarray)
        {
            return JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jarray.ToString());
        }
