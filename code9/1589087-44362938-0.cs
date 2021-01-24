    using(CDIMDEntities oDB = new CDIMDEntities())
    {
        SystemYear oSY = oDB.SystemYears.FirstOrDefault(x => x.Year == Year);
        if (oSY != null)
        {
            string thsQuery = "UPDATE SystemYears SET  " + Column + " = {0} WHERE Id = {1}";
            oDB.Database.ExecuteSqlCommand(thsQuery, Status, oSY.Id);
        
            // Your raw query will not affect the SystemYears at this point.
            oSY = oDB.SystemYears.FirstOrDefault(x => x.Id == oSY.Id);
        
            // This does nothing at this point.
            this.SystemYearRep.SaveSystemYear(oSY);
        }
    }
    // New up a another context
    using(var CDIMDEntities oDB2 = new CDIMDEntities())
    {
       // You will see the changes here
       SystemYear oSY = oDB2.SystemYears.FirstOrDefault(x => x.Year == Year);
    }
