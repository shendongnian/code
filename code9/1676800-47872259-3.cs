    using System;
    using PX.Data;
    namespace InventoryLabelReportExtPkg
    {
	    [Serializable]
	    public class UsrNumbers : IBqlTable
	    {
		    #region Number
		    [PXDBInt(IsKey = true)]
		    [PXUIField(DisplayName = "Number")]
		    public virtual int? Number { get; set; }
		    public abstract class number : IBqlField { }
		    #endregion
	    }
    }
