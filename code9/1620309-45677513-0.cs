    void Main()
    {
        var x = new Test();
        Console.WriteLine(x.GoodProperty); // place a breakpoint on this line
        Console.WriteLine(x.BadProperty);
        Console.WriteLine(x.GoodProperty);
    }
    
    public class Test
    {
        public int GoodProperty { get; set; }
        public int BadProperty => GoodProperty++;
    }
