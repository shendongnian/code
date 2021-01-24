    public class UserViewModel
        {
        [Display(Name = "Other")]
        public string otherProperty {get; set;}
        [Display(Name = "Possible Targets")]
        public List<Target> targets {get; set;}
        [Display(Name = "Possible Results")]
        public List<Result> results{get; set;}
        }
