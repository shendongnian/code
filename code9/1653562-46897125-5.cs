    private string BuildUpdate(string field, string value)
            {
                try
                {
                    //Parameter String
                    string json = string.Empty;
    
                    //Value
                    var dict = new Dictionary<string, string>();
                    dict.Add("operation", "replace");
                    dict.Add("field", field);
                    dict.Add("value", value);
                    json = "[\n" + Regex.Unescape(JsonConvert.SerializeObject(dict, Newtonsoft.Json.Formatting.Indented)) + "\n]";
    
                    return json;
                }
                catch(Exception ex)
                {
                    return null;
                }
            }
