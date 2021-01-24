    private bool IsValidCompanyCustomer()
    {
        var companyValidationRules = new Dictionary<string, Func<Customer, bool>>
        {
            { "Please Check Financial Info.", _checkManager.IsValidFinancialInfo},
            { "Please Check Company Info.", _checkManager.IsValidCompanyInfo},
            { "Please Check Stake Holder Info.", _checkManager.IsValidStakeHolderInfo},
            { "Please Check Responsible person Info.", _checkManager.IsValidResponsiblePersonInfo},
            { "Please Check Screening Info.", _checkManager.IsValidScreeningInfo},
            { "Please Check My Number Upload Info.", _checkManager.IsValidMyNumberUpload},
            { "Please Check Id Upload Status.", _checkManager.IsValidIdUpload},
            { "Please Check Customer Status.", _checkManager.IsValidCustomerStatus},
        };
        var failedRule = companyValidationRules.Where(d => !d.Value(_customer))
                                               .Select(d => d.Key)
                                               .FirstOrDefault();
        if (!string.IsNullOrWhiteSpace(failedRule))
        {
            this.ProcessMessage = failedRule;
            return false;
        }
        return true;
    }
    private bool IsValidPersonalCustomer()
    {
        var companyValidationRules = new Dictionary<string, Func<Customer, bool>>
        {
            { "Please Check Personal Info.", _checkManager.IsValidPersonalInfo},
            { "Please Check Financial Info.", _checkManager.IsValidFinancialInfo},
            { "Please Check Company Info.", _checkManager.IsValidCompanyInfo},
        };
        var failedRule = companyValidationRules.Where(d => !d.Value(_customer))
                                               .Select(d => d.Key)
                                               .FirstOrDefault();
        if (!string.IsNullOrWhiteSpace(failedRule))
        {
            this.ProcessMessage = failedRule;
            return false;
        }
        return true;
    }
}
