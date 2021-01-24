    var groupedSum = invoiced.Union(settled).Union(credit).GroupBy(g => g.Title).Select(g => new Result
    { 
    	Title = g.Key,
    	Credit = credit.Where(c => c.Title == g.Key).Sum(c => c.Amount),
    	Settled = settled.Where(c => c.Title == g.Key).Sum(c => c.Amount),
    	Invoiced = invoiced.Where(c => c.Title == g.Key).Sum(c => c.Amount),
    	SumAmount = g.Sum(i => i.Amount)
    });
