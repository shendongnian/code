    public class Program
    {
    static CoolProgram test;
    static void Main(string[] args)
    {
        test = new CoolProgram();
        test.Start();
    }
    private void Start()
    {
        var arr = new object[]
        {
            1, // int
            1L, // long
            "Hello World" // string
        };
        //test.DoSomething(21474836470);
        foreach (var dyn in arr.Cast<dynamic>())
        {
            test.DoSomething(dyn);
        }
        Console.ReadKey();
    }
    protected virtual void DoSomething(int i)
    {
        Console.WriteLine("Int:" + i);
    }
    protected virtual void DoSomething(string str)
    {
        Console.WriteLine("Str:" + str);
    }
    }
    // from here child class
    public class CoolProgram : Program
    {
      protected override void DoSomething(int i)
      {
        // This works
        Console.WriteLine("Cool Int: " + i);
        base.DoSomething(i);
     }
     protected override void DoSomething(string str)
     {
        // This works
        Console.WriteLine("Cool Str: " + str);
     }
     internal virtual void DoSomething(long i)
     {
        // This is a new method for long
        Console.WriteLine("Long Int:" + i);
     }
     }
