    using (var db = new SystemEntities())
    {
        var record = db.Table.Where(p => p.Id == Id).Max(x => x.ReceivedDateTime).FirstOrDefault()
        if(record != null){}
    }
