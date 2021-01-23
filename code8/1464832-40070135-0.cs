     public List<KeyValuePair<string, string>> GenerateKeyValuePair(Dictionary<string,string> dict) {
                List<KeyValuePair<string, string>> List = new List<KeyValuePair<string, string>>();
                foreach (var item in dict)
                {
                    if (item.Value.Contains(','))
                    {
                        string[] values = item.Value.Split(',');
                        for (int i = 0; i < values.Length; i++)
                        {
                            List.Add(new KeyValuePair<string, string>(item.Key, values[i].ToString()));
                        }
                    }
                    else
                    {
                        List.Add(new KeyValuePair<string, string>(item.Key, item.Value));
                    }
    
                }
                return List;
            }
