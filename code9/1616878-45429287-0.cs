    public class SummaryConfigurationVM
    {
        public int Quarter { get; set; }
        public int Year { get; set; }
        public IEnumerable<SummaryConfiguration> Configurations { get; set; }
        public IEnuemrable<SelectListItem> QuarterList { get; set; }
        public IEnuemrable<SelectListItem> YearListList { get; set; }
    }
