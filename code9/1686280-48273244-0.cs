    static void Main() {
      Dictionary<string, object> testDict = new Dictionary<string, object> {
        { "TestProperty1", 1 },
        { "TestProperty2", "value2" }
      };
      TestClass result = JsonConvert.DeserializeObject<TestClass>(JsonConvert.SerializeObject(testDict));
    }
    class TestClass {
      public object TestProperty1 { get; set; }
      public object TestProperty2 { get; set; }
    }
