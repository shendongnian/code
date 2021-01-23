    string stringA = "503 504 505 506 507 508 503 504 505 506";
	string stringB = "503 504 504 505 506 507 505 508 503 506 505 506 504";
	
	// linq to make dictionary from A
	var mapA = stringA.Split().GroupBy(a => a)
                              .Select(a => new {a.Key,Count = a.Count()})
                              .ToDictionary(a => a.Key, a => a.Count);
	
	// linq to make dictionary from B
	var mapB =  stringB.Split().GroupBy(b => b)
                               .Select(b => new { b.Key, Count = b.Count() })
                               .ToDictionary(b => b.Key, b => b.Count);
	
	// Elements that are in B but not in A 
	var BminusA = mapB.Select(b => new {b.Key, Value = b.Value - mapA?[b.Key] ?? 0})
	                  .Where(difference => difference.Value> 0);
