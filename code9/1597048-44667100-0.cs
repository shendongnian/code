    public class IndividualItemVM
    {
        public string SerialNumber { get; set; }
        public string NSNnumber { get; set; }
        public string Location { get; set; }
        public string User { get; set; }
        public IEnumerable<SelectListItem> NSNlist { get; set; }
    }
