    public class MasterDAC : IBqlTable
    {
        #region LineCntr
        public abstract class LineCntr : IBqlField { }
    
        [PXDBInt]
        [PXDefault(0)]
        public virtual int? LineCntr { get; set; }
        #endregion
    }
