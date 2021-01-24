    public class DetailDAC : IBqlTable
    {
        #region LineNbr
        public abstract class lineNbr : IBqlField { }
    
        [PXDBInt(IsKey = true)]
        [PXDefault]
        [PXLineNbr(typeof(MasterDAC.LineCntr))]
        public virtual int? LineNbr { get; set; }
        #endregion
    }
