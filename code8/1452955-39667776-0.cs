    public class FoodItem
    {
        public FoodItem()
        {
            this.Measures = new HashSet<Measure>();
            this.DiaryEntries = new HashSet<DiaryEntry>();
        }
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<DiaryEntry> DiaryEntries
        {
            get;
            set;
        }
        public virtual ICollection<Measure> Measures
        {
            get;
            set;
        }
    }
