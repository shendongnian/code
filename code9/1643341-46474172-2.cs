    // in practice, we might put this in a using statement
    var db = new MyDbContext();
    var qry = 
        from p in db.Parts
        join c in db.Computers on p.ComputerId equals c.ComputerId
        where p.SerialNumber == mySerialNumber
        select c.PoNumber
    string poNumber = qry.FirstOrDefault();
