    public string ConvertToQueryString(object obj)
    {
	    var properties = from p in obj.GetType().GetProperties()
					 where p.GetValue(obj, null) != null
					 select p.Name + "=" + (
						 p.GetValue(obj, null).GetType().IsArray ?
						 string.Join(",", ((IEnumerable)p.GetValue(obj, null)).Cast<object>().Select(x => x.ToString()).ToArray()) :
						 p.GetValue(obj, null).ToString() 
						 );
	    return string.Join("&", properties.ToArray());
    }
 
