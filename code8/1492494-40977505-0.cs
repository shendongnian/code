    using (var sbc = new SqlBulkCopy(myCOnnection)
    {
    
      sbc.DestinationTableName = "holid";
      sbc.WriteToServer(vacationDT);
    
    }
