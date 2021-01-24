    class Program
    {
        public static Dictionary<String, object[]> ObjectsDictionary { get; set; }
        static void Main(string[] args)
        {
            ObjectsDictionary = new Dictionary<string, object[]>();
            Class1[] classes1 =
            {
                new Class1 {X = 54, Y = 454},
                new Class1 {X = 1, Y = 2}
            };
            Classe2[] classes2 =
            {
                new Classe2 {IsSomthing = true, Name = "String 1 class 2"},
                new Classe2 {IsSomthing = false, Name = "String 2 class 2"}
            };
            ObjectsDictionary.Add("Key 1",classes1);
            ObjectsDictionary.Add("Key 2",classes2);
        }
    }
    class Class1
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    class Classe2
    {
        public String Name { get; set; }
        public Boolean IsSomthing { get; set; }
    }
