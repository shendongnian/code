    public class Foo {
        public String Bar { get; set; }
    }
    ...
    var f = new Foo { Bar = "Initial value" };
    //  Writes "Initial value"
    Console.WriteLine(f.Bar);
