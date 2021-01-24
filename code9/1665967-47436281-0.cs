    string line;
    while ((line = Console.ReadLine()) != null)
    {
       Dictionary<string, int> phoneBook = new Dictionary<string, int>();
       string[] parts;
       parts = line.Split(new char[] {' '}, 2);
       phoneBook[parts[0]] = int.Parse(parts[1]);
    }
