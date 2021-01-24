    class Foo
    {
        public DateTime DateTime { get; set; }
    }
    // This Just Works.
    string json1 = "{ \"DateTime\" : \"12/31/2017\" }";
    string json2 = "{ \"DateTime\" : \"12/31/2017 23:59:59\" }";
    var o1 = JsonConvert.DeserializeObject<Foo>(json1);
    var o2 = JsonConvert.DeserializeObject<Foo>(json2);
