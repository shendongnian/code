    public class InventoryItemExt : PXCacheExtension<PX.Objects.IN.InventoryItem>
    {
        #region UsrCustomField
        [PXString]
        [PXUIField(DisplayName = "Custom Field")]
        public virtual string UsrCustomField { get; set; }
        public abstract class usrCustomField : IBqlField { }
        #endregion
    }
    
    public class SOOrderEntry_Extension : PXGraphExtension<SOOrderEntry>
    {
        protected void SOLine_RowSelected(PXCache cache, PXRowSelectedEventArgs e)
        {
            SOLine soLine = e.Row as SOLine;
    
            if (soLine != null)
            {
                InventoryItem item = (InventoryItem)PXSelectorAttribute.Select<SOLine.inventoryID>(cache, soLine);
    
                if (item != null)
                {
                    InventoryItemExt itemExt = Base.Caches[typeof(InventoryItem)].GetExtension<InventoryItemExt>(item);
                    PXTrace.WriteInformation(string.Concat("Success = ", (itemExt != null).ToString()));
                }
            }
        }
    }
