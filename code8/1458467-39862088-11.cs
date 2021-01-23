    public void MyMethod(string jsonSomeInfo)
    {
      // At this point, jsonSomeInfo is "\"\"",
      // an emmpty string.
      var deserialized = new JsonSerializer().Deserialize(new StringReader(jsonSomeInfo), typeof(string));
      // deserialized = "", event if I used the modified contract resolver [1].
    }
