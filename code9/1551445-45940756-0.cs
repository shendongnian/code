    [Table("mandant", Schema = "public")]
    public class MandantEdm
    {
        public MandantEdm()
        {
        }
        [Key]
        [Column("mandantid", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MandantId { get; set; }
    }
