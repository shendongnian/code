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
            var ListInt1 = new List<int>() { 1, 2 };
            var ListInt2 = new List<int>() { 1, 2, 3 };
            var ListInt3 = new List<TypeForCompare1>() {
                new TypeForCompare1() { Prop1 = new Type1 { Prop1 = 1, Prop2 = "test" }, Prop2 = 1.23 },
            };
            var ListInt4 = new List<TypeForCompare2>() {
                new TypeForCompare2() { Prop1 = new Type1 { Prop1 = 1, Prop2 = "test" }, Prop2 = 1.23 },
            };
            Console.WriteLine(CompareTwoObjects(ListInt1, ListInt2));
            Console.WriteLine(CompareTwoObjects(ListInt3, ListInt4));
            Console.ReadLine();
        }
        static bool CompareTwoObjects(IList obj1, IList obj2)
        {
            var JsonObj1 = new JavaScriptSerializer().Serialize(obj1);
            var JsonObj2 = new JavaScriptSerializer().Serialize(obj2);
            return JsonObj1 == JsonObj2;
        }
    }
