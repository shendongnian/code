    public string Value
    {
      get
      {
        return this.GetValue(true, true) ?? string.Empty;
      }
      ...
    }
