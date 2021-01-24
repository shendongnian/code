    class Program
    {
        static void Main(string[] args)
        {
            Format1 f1 = new Format1("5.10");
            f1.Data.Dic1.Add("Greet", "Hello World");
            f1.Data.Dic2.Add("RepeatGreet", 10);
            f1.Write("f1");
            Console.WriteLine("-------------------------------------------------------");
            Format2 f2 = new Format2("2.1","general",f1.Data);
            f2.Data.Dic1.Add("Goodbye", "See you later, Alligator");
            f2.Data.Dic2.Add("RepeatBye", 1);
            f1.Write("f1");
            f2.Write("f2");
            Console.ReadKey();
        }
    }
    public interface IDataFormat
    {
        void Read(string filename);
        void Write(string filename);
        string Type { get; }
        string Version { get; }
        DataModel Data { get; }
    }
    public class DataModel
    {
        public Dictionary<string, string> Dic1;
        public Dictionary<string, int> Dic2;
        // Constructor
        public DataModel() { Dic1 = new Dictionary<string, string>(); Dic2 = new Dictionary<string, int>(); }
    }
    public class Format1 : IDataFormat
    {
        public string Type { get; }
        public string Version { get; }
        public DataModel Data {get; }
        // Constructors
        public Format1(string version) : this(version, new DataModel()) { }
        public Format1(string version, DataModel data) { Type = "Format1"; Version = version; Data = data; }
        // Concrete implementations of abstract Read and Write for "Format1"
        public void Read(string fileName) { /* do reading stuff */ }
        public void Write(string fileName)
        {
            Console.WriteLine("WRITING " + fileName +" IN FORMAT1:");
            Console.WriteLine("Type: " + Type + "\tVersion: " + Version);
            foreach (KeyValuePair<string, string> kvp in Data.Dic1) { Console.WriteLine("\t" + kvp.Key + "\t" + kvp.Value); }
            foreach (KeyValuePair<string, int> kvp in Data.Dic2) { Console.WriteLine("\t" + kvp.Key + "\t" + kvp.Value); }
        }
    }
    public class Format2 : IDataFormat
    {
        // Properties
        public string Type { get; }
        public string SubType { get; set; }     // A property unique to this class
        public string Version { get; }
        public DataModel Data { get; }
        // Constructors. 
        // Including a constructor which is unique to this class because it uses a unique property of this class
        public Format2(string version) : this(version, "", new DataModel()) { }
        public Format2(string version, DataModel data) : this( version, "", data) { }
        public Format2(string version, string subType, DataModel data) { Type = "Format2"; Version = version; SubType = subType; Data = data; }
        // Concrete implementations of abstract Read and Write for "Format2"
        public void Read(string fileName) { /* do reading stuff */ }
        public void Write(string fileName)
        {
            Console.WriteLine("WRITING " + fileName + " IN FORMAT2:");
            Console.WriteLine("Type: " + Type + "........Version: " + Version);
            foreach (KeyValuePair<string, string> kvp in Data.Dic1) { Console.WriteLine("........" + kvp.Key + "........" + kvp.Value); }
            foreach (KeyValuePair<string, int> kvp in Data.Dic2) { Console.WriteLine("........" + kvp.Key + "........" + kvp.Value); }
        }
    }
