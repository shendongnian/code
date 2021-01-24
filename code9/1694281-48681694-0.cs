     using (TransactionScope scope = new TransactionScope())
          {
    cont.Database.ExecuteSqlCommand("SELECT TOP 1 * FROM Sales__Estimate WITH (TABLOCKX, HOLDLOCK)");
    var result = cont.SalesEstimateCont.Where(x => x.Org_ID == CurrentOrgId);
    var estimationMaxNo = result.Any() ? result.Max(x => x.EstimateNo) + 1 : 1;
    
      var DigitalEstimate = new SalesEstimate()
            {
                EstimateNo=estimationMaxNo;
            };
        cont.Estimate.Add(DigitalEstimate );
        cont.Savechanges();
    }
