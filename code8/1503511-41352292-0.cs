    public class CourseInfo
    {
        public string SelectedMajorCode { get; set; }
        public IList<SelectListItem> AvailableMajorNames { get; set; }
    
        public CourseInfo()
        {
            AvailableMajorNames = new List<SelectListItem>();
        }
    }
