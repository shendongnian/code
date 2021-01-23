    public struct MyStruct
    {
        public int field1 { get; set; }
        public string field2 { get; set; }
        public byte[] field3 { get; set; }
    }
    
    class App
    {      
        static public void SaveData(object obj, string filename)
        {
            // initialization of XML serializer.
            XmlSerializer sr = new XmlSerializer(obj.GetType());
            // get stream from string
            TextWriter writer = new StreamWriter(filename);
            // Serialization 
            sr.Serialize(writer, obj);
            writer.Close();
        }
        static void Main(string[] args)
        { 
            MyStruct st1 = new MyStruct();
            st1.field1 = 10;
            st1.field2 = "hello";
    
            // Converting field1 to bytes.
            Byte[] b = new Byte[st1.field1];
            st1.field3 = b;
    
            SaveData(st1, "text.txt");
        }
    }
