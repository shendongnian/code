    class MyCustomDictionary : Dictionary<string, Aircraft>
    {
      public new Add(string key, Aircraft value)
      {
        if (YOUR_CONDITION)
        {
          base.Add(key, value);
        }
      }
    }
