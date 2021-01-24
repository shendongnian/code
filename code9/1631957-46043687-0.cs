    public void insertComp(string compID, string compName,  string comp_Addressing, string teleComp, string faxComp, string foundDate, string ownername, string license_ID, string taxingID, string licenseExpiring, string cb_country)
    {
        using (IDbConnection Connecting = new System.Data.SqlClient.SqlConnection(connectHelper.CnnVal("hrDB")))
        {
            List<companyModel> companies = new List<companyModel>();
            companies.Add(
                new companyModel { 
                    companyID = compID, 
                    companyName = compName,  
                    company_Address = comp_Addressing,
                    telephoneNumber = teleComp, 
                    faxNumber = faxComp, 
                    foundationDate = foundDate, 
                    ownerName = ownername, 
                    licenseID = license_ID, 
                    taxID = taxingID, 
                    licenseExpire = licenseExpiring, 
                    country = cb_country });
    
            Connecting.Execute("dbo.InsertComp 
                @CompanyID, 
                @CompanyName,  
                @company_Address, 
                @TelephoneNumber, 
                @FaxNumber, 
                @FoundationDate, 
                @OwnerName, 
                @LicenseID, 
                @TaxID, 
                @LicenseExpire, 
                @Country", companies);
        }
    }
