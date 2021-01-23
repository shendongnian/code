    using (var context = new OracleContext(_connString))
    {
        var dbObjT = context.ReportHistoryDatas.FirstOrDefault(x => x.key1.Trim() == "300041" && x.key2== 1);
        if(dbObjT != null)
        {
           dbObjT.DateUpdated = someDate;
    
           //Mark the entity as modified before saving changes.
           context.Entry(dbObjT).State = System.Data.Entity.EntityState.Modified;
    
           context.SaveChanges();
        }
    }
