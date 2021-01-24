    var result = workers
        .Where(w => !exceptWorkerIds.Contains(w.Id))
        .Select(w => new { 
            Name = w.Name, 
            Id = w.Id, 
            Nb = contracts
                .Count(c => c.WorkerId == w.Id && c.ContractDate >= new DateTime(2017,7,1))
        })
        .OrderBy(w => w.Nb).FirstOrDefault();
    if(result != null)
        Console.WriteLine(result.Name);
    else
        Console.WriteLine("Result not found");
