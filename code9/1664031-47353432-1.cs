    public class Killer
    {
        [ForeignKey(nameof(ContractId)]  //Name of added property in line below
        public Contract Contract { get; set; } //no need "virtual"
        public Guid? ContractId { get; set; }
    
        // other properties...
    }
    public class Contract
    {
            [ForeignKey("ContractId")] //Name of added property in Killer Model
            public virtual ICollection<Killer> Killers { get; set; }
            
            // other code... 
    }
