    public class Parent { 
        //...other properties
    
        //Foreign key 
        public string accountid { get; set; }
        //navigation property
        [ForeignKey("accountid")] 
        public ApplicationUser account { get; set; } 
    }
