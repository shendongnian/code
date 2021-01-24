    using PX.Data;
    using PX.Objects.IN;
    namespace PXDemoPkg
    {
        public class INSetupDemoExt : PXCacheExtension<INSetup>
        {
            public abstract class usrInventoryID : IBqlField { }
            #region UsrInventoryID
            [PXDefault]
            [PXUIField(DisplayName = "InventoryID")]
            [InventoryRaw(typeof(Where<InventoryItem.stkItem, Equal<True>>), 
                            DisplayName = "Inventory ID", Filterable = true)]
            public virtual string UsrInventoryID { get; set; }
        
            #endregion
        }
    }
