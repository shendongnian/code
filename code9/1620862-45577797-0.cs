    private void SharingFieldOE2WellOE(InputData inputData)
    {
        IEnumerable<Base> resultsField = new List<Base>();
    
        if (inputData.CashflowModel.Equals("BC"))
        {
           resultsField = new List<ResultsBC>();
        }
        else if (inputData.CashflowModel.Equals("GC"))
        {
           resultsField = new List<ResultsGC>();
        }
    
        // Convert IEnumerable to IList
        List<int> list = resultsField.ToList();
        list[1].Date = "08/08/2017"
    }
