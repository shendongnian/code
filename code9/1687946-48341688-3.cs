    public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
    {
      var result = new Dictionary<string, object>();
      if (obj != null)
      {
        var properties = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var isIgnorable = propertyInfo.GetCustomAttribute<IgnoreIfValueExactlyAttribute>();
          var value = decimal.Parse(propertyInfo.GetValue(obj).ToString());
          if (isIgnorable != null && isIgnorable.ValueToIgnore == value)
            continue;
          result[propertyInfo.Name] = value;
        }
        return result;
      }
      return new Dictionary<string, object>();
    }
