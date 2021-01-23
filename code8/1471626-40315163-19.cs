    public partial class City
    {
        public virtual int Id { get; set; }
    
        private ICollection<CountyCity> _countiesCities;
        public virtual ICollection<CountyCity> CountiesCities
        {
            get { return _countiesCities ?? (_countiesCities = new List<CountyCity>()); }
            set { _countiesCities = value; }
        }
    }
