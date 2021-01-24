    public class CreateDormViewModel {
    
        // used to render the checkboxes, to be filled in GET controller action
        public ICollection<DormHasFeatureModel> AvailableOptions { get; set; }
        
        // used to bind the checked values back to the controller for POST action
        public ICollection<bool> CheckedOptions { get; set; } 
    }
