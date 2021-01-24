    var model = new FilingViewModel();
    foreach (DataRow dr in ds.Tables[0].Rows)
        {
            var filing = new Filing();
            filing.Service = dr.Field<string>("Service");
            filing.filing_Description = dr.Field<string>("filing_Description");
            filing.Date_Post = dr.Field<DateTime>``("Date_Due");
            model.Filings.Add(filing);
        }
