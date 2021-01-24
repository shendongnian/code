         public partial class Product{
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsApproved { get; set; }
        [ForeignKey("CategoryTrans"), Column(Order = 1)]
        public int CategoryID { get; set; }
        [ForeignKey("CategoryTrans"), Column(Order = 2)]
        public int LanguageID { get; set; }
        public virtual Category Category { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual category_trans CategoryTrans { get; set; }
       }
