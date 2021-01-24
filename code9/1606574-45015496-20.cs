    public class CreateDormViewModel {
    
        // used to render the checkboxes, to be initialized in GET controller action
        // also used to bind the checked values back to the controller for POST action
        public ICollection<SelectedFeatureViewModel> DormOptions { get; set; }
    }
