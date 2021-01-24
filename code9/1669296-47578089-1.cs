    public static string FixJson(string json, string property) {
    		var index = json.IndexOf(property);		
    		var indexColon = json.IndexOf(':', index + 1);		
    		var indexComma = json.IndexOf(',', index + 1);		
    		var val = json.Substring(indexColon + 1, indexComma - indexColon - 1);		
    		var replace = string.Format("'{0}': {1}", property, val.Trim());		
    		var forR = string.Format("'{0}': '{1}'", property, val.Trim());		
    		return json.Replace(replace, forR);
    }
