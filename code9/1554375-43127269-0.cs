    /// <summary>
    /// Copy of InventoryRawAttribute (sealed class)
    /// </summary>
    [PXDBString(InputMask = "", IsUnicode = true)]
    [PXUIField(DisplayName = "Inventory ID", Visibility = PXUIVisibility.SelectorVisible)]
    public sealed class TestInventoryRawAttribute : AcctSubAttribute
    {
        public const string DimensionName = "INVENTORY";
        public TestInventoryRawAttribute()
            : base()
        {
            Type SearchType = typeof(Search<InventoryItem.inventoryCD, Where<Match<Current<AccessInfo.userName>>>>);
            PXDimensionSelectorAttribute attr = new PXDimensionSelectorAttribute(DimensionName, SearchType, typeof(InventoryItem.inventoryCD));
            attr.CacheGlobal = true;
            // This is the secret sauce - MaskAutocomplete
            attr.SelectorMode = PXSelectorMode.MaskAutocomplete;
            _Attributes.Add(attr);
            _SelAttrIndex = _Attributes.Count - 1;
        }
    }
