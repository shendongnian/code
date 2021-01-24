    public class TestData
    {
        public string Name;
        public List<Tuple<DateTime, double>> Data;
    }
    [TestMethod]
    public void TestMethod1()
    {
        var json =
        @"{
            name: ""test data"",
            data: [
            [ ""2017-05-31"", 2388.33 ],
            [ ""2017-04-30"", 2358.84 ],
            [ ""2017-03-31"", 2366.82 ],
            [ ""2017-02-28"", 2329.91 ]
            ],
        }";
    
        var result = JsonConvert.DeserializeObject<JObject>(json);
        var data = new TestData
        {
            Name = (string)result["name"],
            Data = result["data"]
                .Select(t => new Tuple<DateTime, double>(DateTime.Parse((string)t[0]), (double)t[1]))
                .ToList()
        };
    
        Assert.AreEqual(2388.33, data.Data[0].Item2);
    }
