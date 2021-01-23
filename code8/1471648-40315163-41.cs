    public partial class One
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        private ICollection<OneTwo> _oneTwos;
        public virtual ICollection<OneTwo> OneTwos
        {
            get { return _oneTwos ?? (_oneTwos = new List<OneTwo>()); }
            set { _oneTwos = value; }
        }
    }
    public partial class Two
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        private ICollection<OneTwo> _oneTwos;
        public virtual ICollection<OneTwo> OneTwos
        {
            get { return _oneTwos ?? (_oneTwos = new List<OneTwo>()); }
            set { _oneTwos = value; }
        }
    }
