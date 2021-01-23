    var contractGroups = contracts.GroupBy(c => c.ContractName);
    foreach(var contractGroup in contractGroups)
    {
        Console.WriteLine(contractGroup.Key + ":");
        foreach(var contractFile in contractGroup)
        {
            Console.WriteLine("ID " + contractFile.ID + " = " + contractFile.Filename);
        }
		
		Console.WriteLine();
	}
