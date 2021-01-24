    public struct MyStruct
    {
        public string Name { get; set; }
    }
....
    MyStruct s = new MyStruct();
    s.Name = "Foo";
    MyStruct s2 = s;
    s2.Name = "Bah";
    Console.Write("Name of MyStruct s: " + s.Name); // Foo not Bah
