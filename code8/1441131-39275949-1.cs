    public void DoStuff()
    {
      string[] items = { "abc", "def", "ghi" };
      List<Model> otherItems = new List<Model> { 
            new Model() { Field1 = "abc", Field2 = "xyz" }, 
            new Model() { Field1 = "abc", Field2 = "xyz" } };
      var result = foo<Model>(items, otherItems, a => a.Field2);
    }
    class Model 
    {
      public string Field1 { get; set; }
      public string Field2 { get; set; }
    }
