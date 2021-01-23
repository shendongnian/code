    var settings = new JsonSerializerSettings()
    {
        TypeNameHandling = TypeNameHandling.Auto,
        Converters = new[] { new UntypedListJsonConverter() }
    };
   
    var str = "{\"Data\": [{\"$type\": \"MyProject.Other, MyProject\", \"Test\": \"Test\"}] }";
    var test = JsonConvert.Deserialize<Test>(str, settings);
    // now these assertions pass
    (test.Data is IList).ShouldBeTrue();
    (((IList)test.Data)[0] is Other).ShouldBeTrue();
