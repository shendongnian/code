    accountModels.Distinct().Select(a => new SummaryModel {
        CompanyCode = a.CompanyCode,
        BusinessCode = a.BusinessCode,
        StateCode = a.StateCode,
        RecordCount = accountModels.Where(
            m => m.CompanyCode == a.CompanyCode && m.BusinessCode = a.BusinessCode && m.StateCode = a.StateCode
        ).Count()
    });
