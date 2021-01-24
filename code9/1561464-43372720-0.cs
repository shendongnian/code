    var input = Console.ReadLine();
    var sb = new StringBuilder(input.Length);
    for (var i = input.Length - 1; i >= 0; --i)
    {
        sb.Append(input[i]);
    }
    Console.WriteLine(sb.ToString());
