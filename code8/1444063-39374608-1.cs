    public partial class teOrder
    {
        public teOrder()
        {
            this.tePersons = new HashSet<tePerson>();
        }
    
        public int OrderId { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<tePerson> tePersons { get; set; }
    }
