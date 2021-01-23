    public class DataStudioGear : DataItem
    {
        string _name;
        private int _moneyValue;
        int _compression;
        int _wideness;
        int _wowFactor;
        public static T DataTestFactory<T>(string name, int value, int comp, int wide, int wow)
        where T : DataStudioGear, new()
        {
            return new T { _name = name, _moneyValue = value, _compression = comp, _wideness = wide, _wowFactor = wow};
        }
    }
    public class Console : DataStudioGear { }
    public class Compressor : DataStudioGear { }
    [TestMethod]
    public void TestDataItemFactory()
    {
        Console console = DataStudioGear.DataTestFactory<Console>("test", 1, 1, 1, 1);
        Compressor compressor = DataStudioGear.DataTestFactory<Compressor>("test", 1, 1, 1, 1);
    }
