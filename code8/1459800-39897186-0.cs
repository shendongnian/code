    public class MainClass
    {
        public string Str1;
    
        public MainClass(string s)
        {
            Str1 = s;
        }
    }
    
    public class Class1 : MainClass
    {
        public string Str2;
    
        public Class1(string s) : base("Hello")
        {
            Str2 = "Goodbye";
        }
    }
