    private static T GetDefaultValue<T>(SettingType s)
    {
      switch(s)
      {
        case s.IntValue:
          return (T)(object)0;
        case s.BoolValue:
          return (T)(object)false;
        case s.DateTimeValue:
          return (T)(object)DateTime.MinValue;
      }
      throw new NotSupportedException("Unsupported type")
    }
