    string[] assignments = new string[] {"A", "B", "C", "D", "E", "F"};
    for (int i = 0; i < 99; i++)
    {
		Console.WriteLine(assignments[i % assignments.Length]);
    }
