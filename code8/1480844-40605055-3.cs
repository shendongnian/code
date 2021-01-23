    public class SubCategories
     {
        public int ID { get; set; }
        public string Name { get; set; }
    
        [ForeignKey("CategoryID")]
        public virtual Categories Categories{ get; set; }//you have to do this
        public int CategoryID { get; set; }
    
        public string LinkToProducts { get; set; }
      }
