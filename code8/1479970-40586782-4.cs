    public static string FixJsonDynamicProperty(string jsonString,char matchChar,string newParamName)
            {
                if (string.IsNullOrEmpty(jsonString)|| string.IsNullOrEmpty(newParamName))
                {
                    return jsonString;
                }
    
                  
                var startIndex = jsonString.IndexOf(matchChar);
                 
                var lastIndex = jsonString.IndexOf(matchChar, jsonString.IndexOf(matchChar) + 1);
    
                if (startIndex >= 0 && lastIndex > startIndex)
                {
                    var dynamicParamName = jsonString.Substring(startIndex, lastIndex - startIndex + 1);
                  
                  return jsonString.Replace(dynamicParamName, newParamName);
                  
                }
    
                return jsonString;
            }
