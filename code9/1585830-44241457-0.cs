    public bool IsSomeType(string[] partnerTypeNames)
    {
        if ((NameOfYourPositiveCase(partnerTypeNames)
        && (NameOfYourNegativeCase(partnerTypeNames))
        {
            /*here the logic*/
        }
    }
    
    public bool NameOfYourPositiveCase(string[] partnerTypeNames) {
        return ((partnerTypeNames.Any("PSUD".Contains)
            || partnerTypeNames.Any("PDST".Contains)
            || partnerTypeNames.Any("PDLR".Contains));
    }
    public bool NameOfYourNegativeCase(string[] partnerTypeNames) {
        return !partnerTypeNames.Any("SERP".Contains)
                || !partnerTypeNames.Any("Contractors".Contains);
    }
