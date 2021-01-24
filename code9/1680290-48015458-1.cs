    string input = "hello how are you";
    string[] inputParts = input.Split(' ');
    List<string> subphrases = new List<string>();
    for (int i = 0; i < inputParts.Length-1; i++)
    {
        subphrases.Add(string.Join(" ", inputParts.Skip(i)));
    }
