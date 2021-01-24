    [StructLayout(LayoutKind.Explicit)]
    public struct MyStructHack
    {
        [FieldOffset(0)]
        public Foo a;
    
        [FieldOffset(0)]
        public Bar b;
    }
    
    public struct Foo { public int foo; }
    public struct Bar { public int bar;}
    
    var convert = new MyStructHack();
    convert.a = new Foo {foo = 3};
    var bar = convert.b;
    Console.WriteLine(bar.bar);
