    public class ProjectViewModel
    {
        public ProjectViewModel()
        {
            ProjectTypes = new List<SelectListItem>();
        }
        public string SelectedProject { get; set; }
        public List<SelectListItem> ProjectTypes { get; set; }
    }
    
