    public class Class1
    {
        public string Str1;
        public Class1() { Str1 = "Hello"; }
        public Class1(string s) { Str1 = s; }
    }
    public class Class2 : Class1
    {
        public string Str2;
        public Class2() { Str2 = "World"; }
        public Class2(string s)  : base(s) // calls Class1(string s)
        {
            Str2 = s;
        }
    }
