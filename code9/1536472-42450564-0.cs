    public class Presenter
    {
        public IPagedList<Task> Tasks { get; set; }
        public int? Status { get; set; } // note nullable
        ... // add any other properties of TasksFiltersViewModel 
        public int PageNumber { get; set; }
        public IEnumerable<SelectListItem> Statuses { get; set; }
    }
