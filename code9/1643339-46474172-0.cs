    // in practice, we might put this in a using statement
    var db = new MyDbContext();
    var qry = 
        from p in db.Parts
        join c in db.Computers on p.ComputerId equals c.ComputerId
        select p.PoNumber == null ? c.PoNumber : p.PoNumber
    string poNumber = qry.FirstOrDefault();
