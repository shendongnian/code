    public static class Extensions {
    	public static void AppendToValues(this Dictionary<long, List<string>> dict, long key, string str){
    		if (dict.ContainsKey(key)) {
    			dict.Add(key, new List<string>());
    			}
    		dict[key].Add(str);
    		}
    	}   
