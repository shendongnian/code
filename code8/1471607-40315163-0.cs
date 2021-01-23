    public partial class One
    {
        public virtual int Id { get; set; }
    
        private ICollection<Two> _twos;
        public virtual ICollection<Two> Twos
        {
            get { return _twos?? 
                         (_twos= new List<Two>()); }
            set { _twos= value; }
        }
    }
