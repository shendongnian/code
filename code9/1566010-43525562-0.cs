    public class MyVars
    {
        public string databaseHost;
        public string databaseUsername;
        public string databasePassword;
        public string databaseName;
    }
    var instance = new MyVars();
    var type = typeof(MyVars);
    File.ReadAllLines("config.txt").
         Select(l => l.Split(new char[]{'=',';'})).
         ForEach(a => type.GetField(a[0].Trim()).
         SetValue(instance, a[1].Trim())); 
