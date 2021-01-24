    public class Message
    {
        public int Number { get; set; }
        public List<Field> Fields { get; set; }
    }
    
    public class Field
    {
        public string Name { get; set; }
        public int ByteOffset { get; set; }
        public int ByteSize { get; set; }
    }
