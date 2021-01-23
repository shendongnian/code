    public class Settings
    {
        public int appWidth = 800;
        public int appHeight = 600;
        public int layotCols = 1;
        public int layotRows = 1;
        public string TestString = "test";
        public double TestFloat = 1.4;
        public string[] TestStringArray = new[] { "1", "ee", "rrr"};
        public List<string> TestStringArray1 = new List<string>() { "1", "2"};
        public Dictionary<string,string> TestStringArray2 = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } };
    }
    public static class App
    {
        public static Settings settings = new Settings();
    }
   
