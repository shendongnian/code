    static void Main(string[] args)
    {
        object x = 6.4; 
        switch (x)
        {
            case string _:
                Console.WriteLine("it is string");
                break;
            case double _:
                Console.WriteLine("it is double");
                break;
            case int _:
                Console.WriteLine("it is int");
                break;
            default:
                Console.WriteLine("it is Unknown type");
                break;
        }
        // end of main method
    }
