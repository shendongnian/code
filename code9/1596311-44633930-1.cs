    public class Medicine 
    {
        // Whatever other stuff you have declared
        ...
        [Ignore]
        public virtual ICollection<Medicine_Incident> Medicine_Incident { get; set; }
    }
