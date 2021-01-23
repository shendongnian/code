    public partial class WarrantyFormLineReplacements
    {
        #region Class Variables
        public int in_WFLineReplacementID;
        public int in_WFlineId;
        public int in_WFId;
        [MaxLength(120)]
        public string vc_ModelNumber;
        public decimal dc_ReplacementCost;
        [MaxLength(255)]
        public string vc_InsertBy;
        public DateTime dt_InsertDate;
        [MaxLength(255)]
        public string vc_UpdateBy;
        public DateTime dt_UpdateDate;
        #endregion
    }       // end of public partial class WarrantyFormLineReplacements
