    var winner =node.Connections.Where(n => n.HQ != null) // this is checking the connection where HQ is not null
        .GroupBy(n=>n.HQ) // grouping based on HQ
        .Select(g => new { Cantidate = g.Key, Count = g.Count() }) // creating an enumerable anonymous type with cantidate , count
        .OrderByDescending(g => g.Count) // sorting this enumerable  type in type order based on the count
        .First() // take the first element from this enumerable type
        .Cantidate; // get the value of cantidate of that first element 
