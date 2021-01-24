    public class Methods
    {
        public void TestMethod(List<TestObject> list)
        {
            Dictionary<string, TestObject> data = list.ToDictionary(x => x.Key);
        }
    }
