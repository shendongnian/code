    string a = "This is a long phrase to test the splitting around the middle space";
    string[] parts = a.Split(' ');
    string first = string.Join(" ", parts.Take(parts.Length / 2));
    string second = string.Join(" ", parts.Skip(parts.Length / 2));
    Console.WriteLine(first);
    Console.WriteLine(second);
