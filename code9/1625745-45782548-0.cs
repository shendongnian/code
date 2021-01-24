    var result = workers.Select(w => new { 
            Name = w.Name, 
            Id = w.Id, 
            Nb = contracts
                .Count(c => c.WorkerId == w.Id && c.ContractDate >= new DateTime(2017,7,1))
        }).OrderBy(w2 => w2.Nb).FirstOrDefault();
    if(result != null)
        Console.WriteLine(result.Name);
    else
        Console.WriteLine("Result not found");
