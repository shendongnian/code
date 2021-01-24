        string getJsonStringFromQueryString()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            var nvc = Request.QueryString;
            foreach (string key in nvc.Keys)
            {
                string[] values = nvc.GetValues(key);
                string tempKey = key;
                tempKey = tempKey.Replace("[", ".").Replace("]", "");
                if (values.Length == 1)
                    dic.Add(tempKey, values[0]);
                else
                    dic.Add(tempKey, values);
            }
            string vald = Request.QueryString["ob"];
            var result = makeNestedObject(dic);
            var json = new JavaScriptSerializer().Serialize(result);
            return json;
        }
        
        Dictionary<string, object> makeNestedObject(Dictionary<string, object> qsDictionar)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            foreach (string key in qsDictionar.Keys)
            {
                if (key.Contains("."))
                {
                    List<string> keysList = key.Split('.').ToList();
                    Dictionary<string, object> lastAddedDictionary = result;
                    while (keysList.Count > 1)
                    {
                        if (!lastAddedDictionary.ContainsKey(keysList[0]))
                        {
                            Dictionary<string, object> temp = new Dictionary<string, object>();
                            lastAddedDictionary[keysList[0]] = temp;
                            lastAddedDictionary = temp;
                        }
                        else                        
                            lastAddedDictionary = (Dictionary<string, object>)lastAddedDictionary[keysList[0]];                        
                        keysList.RemoveAt(0);
                    }
                    lastAddedDictionary[keysList[0]] = qsDictionar[key];
                }
                else
                {
                    result.Add(key, qsDictionar[key]);
                }
            }
            return result;
        }
