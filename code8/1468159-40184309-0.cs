    Console.WriteLine("Enter value:");
    string stringValue = Console.ReadLine();
    int intValue;
    if(int.TryParse(stringValue, out intValue))
    {
        // this is int! use intValue variable
    }
    else
    {
        // this is string! use stringValue variable
    }
