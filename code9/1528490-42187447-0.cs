     public class Ads
     {
        public Ads()
        {
            AdsCategories= new HashSet<AdsCategory>();
        }
        public int AdsId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AdsCategory> AdsCategories { get; set; }
     }
     public class AdsCategory
     {
        public AdsCategory()
        {
            Ads= new HashSet<Ads>();
        }
        public int AdsCategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Ads> Ads { get; set; }
     }
