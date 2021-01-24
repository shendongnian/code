    private string BuildUpdate(string field, string newvalue, string oldvalue)
            {
                try
                {
                    //Parameter String
                    string Update = string.Empty;
    
                    //New Value
                    var dict1 = new Dictionary<string, string>();
                    dict1.Add("operation", "replace");
                    dict1.Add("field", field);
                    dict1.Add("value", newvalue);
                    string json1 = Regex.Unescape(JsonConvert.SerializeObject(dict1, Newtonsoft.Json.Formatting.Indented));
    
                    //Current Value
                    var dict2 = new Dictionary<string, string>();
                    dict2.Add("operation", "replace");
                    dict2.Add("field", field);
                    dict2.Add("value", oldvalue);
                    string json2 = Regex.Unescape(JsonConvert.SerializeObject(dict2, Newtonsoft.Json.Formatting.Indented));
    
                    Update = json1 + ",\n " + json2;
    
                    return Update;
                }
                catch(Exception ex)
                {
                    return null;
                }
            } 
     
