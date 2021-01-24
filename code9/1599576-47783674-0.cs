    using System.ComponentModel.DataAnnotations;    
    public enum OpeningHubOptions
        {
            [Display(Name = "Yes, I want to be a DayNinja")]
            Yes = 1,
        
            [Display(Name = "No, I don't want to unlock flow to achieve my goals.")]
            No = 2,
        
            [Display(Name = "Later, I''ll start with the basics")]
            Later = 3
        }
