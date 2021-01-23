    public List<SelectListItem> GetSelectListItems<TEnum>() where TEnum : struct
    {
      if (!typeof(TEnum).IsEnum)
        throw new ArgumentException("Type parameter must be an enum", nameof(TEnum));
      var selectList = new List<SelectListItem>();
      var enumValues = Enum.GetValues(typeof(TEnum)) as TEnum[];
      // ...
