    var linkPasses = new List<Passenger>();
    var Passes = _context.Passengers.Include(c => c.Passengers).Where(m => m.ID == id); 
    foreach(Passenger tmpPass in Passes)
        foreach(Passenger tmpPass2 in tmpPass.Passengers) 
           linkPasses.Add(tmpPass2);**
