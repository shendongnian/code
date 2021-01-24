    static void Main(string[] args)
    {
        int? test1 = null;
        SomeMethod(ref test1);
        Console.WriteLine(test1);
        // Display 456
    
        int? test2 = 123;
        SomeMethod(ref test2);
        Console.WriteLine(test2);
        // Display 123
    
        Console.ReadLine();
    }
    
    static void SomeMethod(ref int? parameter)
    {
        if (parameter == null)
        {
            parameter = 456;
        }
    }
