    public class ViewModel
    {
        public ObservableCollection<Instructor> Instructors {get; set}
        public void RetrieveInstructorsFromService()
        {
             // the service needs to populate all properties of the Instructor isntance.
             var instructors = service.GetInstructors();
             this.Instructors = new ObservableCollection<Instructor>(instructors);
        }
    }
    public class Instructor
    {
        [...]
        public string Description { get; set; }
        public string ImageSource { get; set; }
        [...]
    }
