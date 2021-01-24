    public interface ITable
    {
        string Name { get; set; }
    }
    public class Table : ITable
    {
        public Table(string name)
        {
            this.Name = name;
        }
        public string Name {get;set;}
    } 
    public static class TableManager
    {  
        private static Dictionary<string, ITable> _tableDict = new Dictionary<string, ITable>();
        public static Dictionary<string, ITable> getDict
        {
            get { return _tableDict; }
        }
        public static void addTable(string name)
        {
            _tableDict[name] = new Table(name);
        }
    }
