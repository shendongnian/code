    class CompanyInfo
    {
        public string CompanyName { get; set; }
        public List<CompanyItem> CompanyItems { get; set; }
    }
    class CompanyItem
    {
        public string GradeName { get; set; }
        public string SeriesName { get; set; }
        public string PaybandName { get; set; }
        public bool Authorized { get; set; }
        public int Assigned { get; set; }
    }
