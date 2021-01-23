    List<SummaryModel> summaryModels = accountModels.GroupBy(accountModel => new {
        accountModel.CompanyCode
        accountModel.BusinessCode
        accountModel.StateCode
    }).Select(amSummary => new SummaryModel {
        CompanyCode = amSummary.Key.CompanyCode,
        BusinessCode = amSummary.Key.BusinessCode,
        StateCode = amSummary.Key.StateCode,
        RecordCount = amSummary.Count() 
    }).ToList();
