    public static dynamic ToDynamic<T>(this T obj)
    {
      var json = JsonConvert.SerializeObject(obj);
      return JsonConvert.DeserializeObject(json, typeof(ExpandoObject));
    }
