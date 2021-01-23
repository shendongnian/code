    public partial class WarrantyFormLineReplacements
    {
        #region Class Variables
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int in_WFLineReplacementID {get;set;}
        public int in_WFlineId { get; set; }
        public int in_WFId { get; set; }
        [MaxLength(120)]
        public string vc_ModelNumber { get; set; }
        public decimal dc_ReplacementCost { get; set; }
        [MaxLength(255)]
        public string vc_InsertBy { get; set; }
        public DateTime dt_InsertDate { get; set; }
        [MaxLength(255)]
        public string vc_UpdateBy { get; set; }
        public DateTime dt_UpdateDate { get; set; }
        #endregion
    }       // end of public partial class WarrantyFormLineReplacements
