    class Program
    {
        static void Main(string[] args)
        {
            var smallList = new List<MyStruct>()
            {
                new MyStruct { Field1="1f", Field2 ="2f" },
                new MyStruct { Field1="2f", Field2 ="22f" }
            };
            var bigList = new List<MyStruct>()
            {
                new MyStruct { Field1="1f", Field2 ="2f" },
                new MyStruct { Field1="3f", Field2 ="22f" },
                new MyStruct { Field1="4f", Field2 ="22f" }
            };
            var result = bigList.Except(smallList);
            Console.ReadLine();
        }
    }
    public struct MyStruct
    {
        public string Field1;
        public string Field2;
        public override bool Equals(object obj)
        {
            return Field1 == (obj as Nullable<MyStruct>).Value.Field1;
        }
    }
