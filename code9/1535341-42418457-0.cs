    dynamic o1 = new System.Dynamic.ExpandoObject();
    o1.hello = "Hello";
    dynamic o2 = new System.Dynamic.ExpandoObject();
    o2.number = 42;
    o2.AnotherNum = 43;
    JsonConvert.SerializeObject(new []{o1,o2});
