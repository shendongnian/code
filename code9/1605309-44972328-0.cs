    public class Description: IEntity<int>
    {
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        public DateTime Created { get; set; }
    
        public DateTime Updated { get; set; }
    
        [MaxLength(256)]
        public string Heading { get; set; }
    
        [Key, Column(Order = 1)]
        public int ArticleId { get; set; }
    
        public virtual Article Article { get; set; }
    }
