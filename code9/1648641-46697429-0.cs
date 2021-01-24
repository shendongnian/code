    [Table("EPW_AREAS", Schema="CELG")]
    public class Area
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("AREA_CODE")]
        public int AreCode { get; set; }
        [Column("AREA_NAME")]
        public string AreName { get; set; }
    }
