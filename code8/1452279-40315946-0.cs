    public class ListRelations : EntityData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string userID { get; set; }
        public bool read { get; set; }
        public bool write { get; set; }
    }
