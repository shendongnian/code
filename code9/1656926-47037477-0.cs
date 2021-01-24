    var dictionary = new Dictionary<string, object>
    {
        {"Name", "Erik"},
        {"HomeAddress", new Dictionary<string, object>
        {
            {"Street", "Foo"}
        }}
    };
    var json = JsonConvert.SerializeObject(dictionary);
    var person = JsonConvert.DeserializeObject<Person>(json);
