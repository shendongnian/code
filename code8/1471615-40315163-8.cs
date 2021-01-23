    public partial class CountyCity
    {
        public virtual int CountyId { get; set; }
        public virtual int CityId { get; set; }
        public virtual County County { get; set; }
        public virtual City City { get; set; }
    }
