    private class StaggingAttorney : CourtCase.Attorney
    {
        public bool scraping = false;
    
        public bool scraped = false;
    
        public string caseNumber;
    
        public CourtCase.Attorney toAttorney()
        {
            CourtCase.Attorney attorney = new CourtCase.Attorney()
            {
                names = this.names,
                matchString = this.matchString,
                [... Initialize the other properties ...]
            };
            return attorney;
        }
    
    }
