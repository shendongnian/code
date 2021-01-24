    class AgeGroup {
     public ICollection<Apps> Apps { get; set; }
     // your other properties here
    
      public AgeGroup() {
       Apps = new Collection<Apps>();
     }
    }
