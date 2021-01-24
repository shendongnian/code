      public static object With(this object obj, object additionalProperties)
      {
        var type = additionalProperties.GetType();
        foreach (var sourceField in type.GetFields())
        {
          var name = sourceField.Name;
          var value = sourceField.GetValue(additionalProperties);
          if (type.GetMember(name)[0] is FieldInfo)
            type.GetField(name).SetValue(obj, value);
          else
            type.GetProperty(name).SetValue(obj, value);
        }
        return obj;
      }
