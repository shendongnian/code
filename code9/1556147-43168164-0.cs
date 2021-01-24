    [TestClass]
    public class JsonNetDateSerializationTests {
        [TestMethod]
        public void GetResults() {
            //Arrange
            var json = "{\"result\": [[\"2016-10-31 01:29:42 495000\", 1033], [\"2016-11-01 22:29:07 169000\", 1033], [\"2016-10-31 01:31:51 550000\", 1033], [\"2016-11-01 22:41:11 357000\", 1033], [\"2016-11-01 22:41:11 357000\", 1033], [\"2016-11-01 22:52:09 848000\", 1033], [\"2016-11-03 01:48:13 038000\", 1033], [\"2016-11-03 01:48:13 038000\", 1033]], \"columns\": [\"ctime\", \"records\"], \"elapsed\": 0.000726}";
            //Act
            var actual = JsonConvert.DeserializeObject<Data>(json);
            //Assert
            Assert.IsNotNull(actual);
            var results = actual.result;
            var value1a = results[0][0];
            var value1b = results[0][1];
        }
        public class Data {
            public IList<IList<object>> result { get; set; }
            public IList<string> columns { get; set; }
            public double elapsed { get; set; }
        }
    }
