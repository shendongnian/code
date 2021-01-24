    public static List<T> GetFlagEnumAttributes<T>(this Enum flagEnum) where T : Attribute
    {
       var type = flagEnum.GetType();
       return Enum.GetValues(type)
          .Cast<Enum>()
          .Where(flagEnum.HasFlag)
          .Select(e => type.GetMember(e.ToString()).First())
          .Select(info => info.GetCustomAttribute<T>())
          .Where(attribute => attribute != null)
          .ToList();
    }
