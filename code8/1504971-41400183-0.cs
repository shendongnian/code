    prop int AgreementID
    prop int ClientID
    prop DateTime Date
    prop ClientObject CO;
    
    public IEnumerable<Agreement> GetAllAgreements()...
    
    public override string ToString()
    {
       return this.CO.FullName;
    }
    
    
    -----------
    mydropdown.DataSource = GetAllAgreements(); Databind();
