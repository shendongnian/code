    List<ProviderQualificationDetail> providerQualificationDetail = new List<ProviderQualificationDetail>();
    
    foreach (ProviderModel providers in allProviders)
    {
        if(!providerQualificationDetail.Any(p=>p.ProviderName.Contains(providerName)))
        {
            ProviderQualificationDetail ProviderQualificationDetail = new ProviderQualificationDetail();
            ProviderQualificationDetail.ProviderName = providerName;
            ProviderQualificationDetail.ProviderQualificationTime = Math.Round(processingTime).ToString();
            ProviderQualificationDetail.TotalServiceableOffers = "Not serviceable";
            providerQualificationDetail.Add(ProviderQualificationDetail);
        }
        else
        {
    var qualificationDetail = providerQualificationDetail.SingleOrDefault(p => p.ProviderName.Equals(providerName));
    //Assing your values here
    //example; 
    qualificationDetail.ProviderName = NewProviderName.ToString();
    providerQualificationDetail.SaveChanges();
        }
    }
