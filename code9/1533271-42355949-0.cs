    string valueField = "";
    
    [JsonProperty]
    public string Value 
    { 
       get{
           return valueField.ToLower();
        }
       set{
          value = valueField;
       }
    }
