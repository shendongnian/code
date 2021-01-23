    public partial class Two
    {
        public virtual int Id { get; set; }
    
        private ICollection<One> _ones;
        public virtual ICollection<One> Ones
        {
            get { return _ones?? 
                         (_ones= new List<One>()); }
            set { _ones= value; }
        }
    }
