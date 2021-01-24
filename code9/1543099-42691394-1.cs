    [DynamicUriParameter(Description = "Some description", Name ="Some name", Type =typeof(string))]
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }
