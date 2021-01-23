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
    // ...or create more specific container objects for the result
    var contractFiles = contractGroups.Select(cg => new { ContractName = cg.Key, Files = cg.Select(file => new { file.ID, file.Filename }) });
