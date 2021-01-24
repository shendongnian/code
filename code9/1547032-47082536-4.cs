    public static dynamic ToDynamic(this object obj)
    {
      var json = JsonConvert.SerializeObject(obj);
      return JsonConvert.DeserializeObject(json, typeof(ExpandoObject));
    }
