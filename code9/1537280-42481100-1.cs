    [Table("entities")]
    public class Entity 
    {
        [Key]
        [Column("id")]
        // this you need to tell to Ef to use Identity .
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
    
        [Column("field")]
        public string Field { get; set; }
    }
