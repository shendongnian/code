    Thread task = new Thread(()=>
    {
         try
         {
             ConnectToCodeManager();
             string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnection"].ConnectionString;
             SQLTrazabilidadStorage storage = new SQLTrazabilidadStorage(connectionString);
             storage.SendAggregation(parentCode, codesManagerURL);
         }
         catch (Exception ex)
         {
             log.Error(string.Format("SendAggregation to TrzCodesManagerWS: {0}", ex.ToString()));
         }
    });
    task.Start();
