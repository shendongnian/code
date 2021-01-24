    public static class JsonExtensions
    {
    	public static void Capitalize(this JArray jArr)
    	{
    		foreach(var x in jArr.Cast<JToken>().ToList())
    		{
    			var childObj = x as JObject;
    			if(childObj != null)
    			{
    				childObj.Capitalize();
    				continue;
    			}
    			var childArr = x as JArray;
    			if(childArr != null)
    			{
    				childArr.Capitalize();
    				continue;
    			}
    		}
    	}
    	public static void Capitalize(this JObject jObj)
    	{
    		foreach(var kvp in jObj.Cast<KeyValuePair<string,JToken>>().ToList())
    		{
    			jObj.Remove(kvp.Key);
    			var newKey = kvp.Key.Capitalize();
    			var childObj = kvp.Value as JObject;
    			if(childObj != null)
    			{
    				childObj.Capitalize();
    				jObj.Add(newKey, childObj);
    				return;
    			}
    			var childArr = kvp.Value as JArray;
    			if(childArr != null)
    			{
    				childArr.Capitalize();
    				jObj.Add(newKey, childArr);
    				return;
    			}
    			jObj.Add(newKey, kvp.Value);
    		}
    	}
        public static string Capitalize(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("empty string");
            }
            char[] arr = str.ToCharArray();
            arr[0] = char.ToUpper(arr[0]);
            return new string(arr);
        }
    }
