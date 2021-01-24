    switch (s)
    {
        case string x when x.Length == 3 && int.TryParse(x, out int i):
            Console.WriteLine($"s is a string that parses to {i}");
            break;
        // will not compile with error
        // An expression of type string cannot be handled by a pattern of type int.
		case int x:
		    break;
        // will win pattern matching and print the line
        // {s} is an object
		case object x:
            Console.WriteLine($"{s} is an object");
        default:
            Console.WriteLine("No Match.");
            break;
    }
