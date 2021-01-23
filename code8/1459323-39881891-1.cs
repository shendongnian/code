    public class Outeritem
        {
            public List<List<object>> inneritems { get; set; }
        }
        public class RootValue
        {
            public List<Outeritem> outeritems { get; set; }
        }
        [TestMethod]
        public void SerializeAndDeserializeTest()
        {
            var expected = "{\"outeritems\":[{\"inneritems\":[[{\"itemid\":\"1\"},{\"itemid\":\"2\"}]]}]}";
            var rootValue = new RootValue
            {
                outeritems = new List<Outeritem>
                {
                    new Outeritem
                    {
                        inneritems = new List<List<object>> {
                            new List<object> { new {itemid = "1"},new {itemid = "2"} }
                        }
                    }
                }
            };
            var actual = JsonConvert.SerializeObject(rootValue);
            Assert.AreEqual(expected, actual);
        }
