    private void SharingFieldOE2WellOE(InputData inputData)
    {
        IEnumerable<IResults> resultsField = null;
    
        if (inputData.CashflowModel.Equals("BC"))
        {
           resultsField = new List<ResultsBC>();
        }
        else if (inputData.CashflowModel.Equals("GC"))
        {
           resultsField = new List<ResultsGC>();
        }
    
        // Convert IEnumerable to IList
        List<IResults> list = resultsField.ToList();
        list[1].Date = "08/08/2017"
    }
