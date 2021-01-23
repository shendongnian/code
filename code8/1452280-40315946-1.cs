    public class ListRelations : EntityData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity),
         Column(TypeName = "varchar"),
         MaxLength(20),
         Key]
        public string userID { get; set; }
        public bool read { get; set; }
        public bool write { get; set; }
    }
