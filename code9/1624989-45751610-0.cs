    public ZipInfoEntity
    {
        public string Zip {get;set;}
        public string StateName {get;set;}
        public string StateAbbr {get;set;}
        public FipsCountyInfoEntity FipsCountyInfo {get;set;} // <-- use class, not IList
    }
