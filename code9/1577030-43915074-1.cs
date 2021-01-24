    class Type1
    {
        public int Prop1 { get; set; }
        public string Prop2 { get; set; }
    }
    class TypeForCompare1
    {
        public Type1 Prop1 { get; set; }
        public double Prop2 { get; set; }
    }
    class TypeForCompare2
    {
        public Type1 Prop1 { get; set; }
        public double Prop2 { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var List1 = new List<int>() { 1, 2 };
            var List2 = new List<int>() { 1, 2, 3 };
            var List3 = new List<TypeForCompare1>() {
                new TypeForCompare1() { Prop1 = new Type1 { Prop1 = 1, Prop2 = "test" }, Prop2 = 1.23 },
            };
            var List4 = new List<TypeForCompare2>() {
                new TypeForCompare2() { Prop1 = new Type1 { Prop1 = 1, Prop2 = "test" }, Prop2 = 1.23 },
            };
            Console.WriteLine(CompareTwoObjects(List1, List2));
            Console.WriteLine(CompareTwoObjects(List3, List4));
            Console.ReadLine();
        }
        static bool CompareTwoObjects(IList obj1, IList obj2)
        {
            var JsonObj1 = new JavaScriptSerializer().Serialize(obj1);
            var JsonObj2 = new JavaScriptSerializer().Serialize(obj2);
            return JsonObj1 == JsonObj2;
        }
    }
