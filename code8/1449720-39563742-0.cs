        public class Report
        {
            [Required]
            public string State { get; set; }
        
            [ForeignKey("UserId")]
            public virtual AspNetUser { get; set; }
            public int UserId { get; set; }
        
            [Required]
            [Column("report_text")]
            public string ReportText { get; set; }
            
        }
    
      public class AspNetUser
        {
          public int Id { get; set; }
    
          public string Name { get; set; }
    
          public virtual ICollection<Report> Reports { get; set;} 
       }
