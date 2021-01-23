    HistoricalDataService service = new HistoricalDataService (dbcontext);
    
    try 
    {
         service.AddHistoricalData(HistoricalData instance);
         service.ProcessAllData();
         service.SaveData();
    }
    catch (Exception ex)
    {
         service.Rollback();
    }
