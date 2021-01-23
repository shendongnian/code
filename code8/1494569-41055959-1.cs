    public class Orders
    {
        public List<Type1> tp1 { get; set; }
        public List<Type2> tp2 { get; set; }
        public List<Type3> tp3 { get; set; }
    }
    public class Type1
    {
        public string name { get; set; }
    }
    public class Type2
    {
        public string name { get; set; }
    }
    public class Type3
    {
        public List<Type1> tp1 { get; set; }
        public List<Type2> tp2 { get; set; }
    }
