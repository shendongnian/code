    public class MyValue
    {
        public string Value { get; set; }
    }
    var actual = new MyValue { Value = "world" };
    var reference = actual;
    reference.Value = "you";
    Console.WriteLine($"Hello {actual.Value}"); // Hello you
