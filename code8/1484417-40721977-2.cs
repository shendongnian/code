    string input = "Abc 123 456"
    string[] parts = input.Split(); //Whitespaces are assumed as separators by default.
    if (parts.Count == 3) {
        Console.WriteLine("The text is \"{0}\"", parts[0]);
        int n1;
        if (Int32.TryParse(parts[1], out n1)) {
            Console.WriteLine("The 1st number is {0}", n1);
        } else {
            Console.WriteLine("The second part is supposed to be a whole number.");
        }
        int n2;
        if (Int32.TryParse(parts[2], out n2)) {
            Console.WriteLine("The 2nd number is {0}", n2);
        } else {
            Console.WriteLine("The third part is supposed to be a whole number.");
        }
    } else {
        Console.WriteLine("You must enter three parts separated by a space.");
    }
