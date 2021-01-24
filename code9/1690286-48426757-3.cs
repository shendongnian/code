    Console.Write("Insert string: ");
    string input = Console.ReadLine();
    char[] charArray = new char[input.Length];
    var newString = string.Empty;
    
    for (int i = 0; i < input.Length; i++)
    {
        if (Char.IsWhiteSpace(input, i))
        {
            continue;
        }
        else
        {
            newString += input[i];
        }
     }
    Console.WriteLine(newString);
