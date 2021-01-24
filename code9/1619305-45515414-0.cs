    class Program
    {
        [Serializable]
        public class MyClass
        {
            public string Property1{ get; set; }
            public string Property2 { get; set; }
        }
    
        static void Main(string[] args)
        {
            var item = new MyClass();
            item.Property1 = "value1";
            item.Property2 = "value2";
            
            // write to file
            FileStream s = new FileStream("myfile.bin", FileMode.Create);
            BinaryFormatter f = new BinaryFormatter();
            f.Serialize(s,item);
            s.Close();
    
            // read from file
            FileStream s2 = new FileStream("myfile.bin", FileMode.OpenOrCreate,FileAccess.Read);
            MyClass item2 = (MyClass)f.Deserialize(s2);
        }
    }
