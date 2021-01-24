        public class INItemClassMaintExt : PXGraphExtension<INItemClassMaint>
        {
            [Serializable]
            public class CreateStockItemParams : IBqlTable
            {
                #region InventoryCD
                public abstract class inventoryCD : PX.Data.IBqlField
                {
                }
                [PXString]
                [PXUIField(DisplayName = "Inventory ID")]
                public virtual string InventoryCD { get; set; }
                #endregion
            }
            public PXFilter<CreateStockItemParams> CreateStockItemDialog;
            public PXDBAction<INItemClass> CreateStockItem;
            [PXButton]
            [PXUIField(DisplayName = "Create Stock Item")]
            protected void createStockItem()
            {
                var result = CreateStockItemDialog.AskExt((graph, viewname) =>
                {
                    CreateStockItemDialog.Cache.Clear();
                });
                if (result != WebDialogResult.OK) return;
                var itemParams = CreateStockItemDialog.Current;
                if (string.IsNullOrEmpty(itemParams.InventoryCD))
                {
                    CreateStockItemDialog.Cache.RaiseExceptionHandling<CreateStockItemParams.inventoryCD>(itemParams,
                        itemParams.InventoryCD, new PXSetPropertyException(ErrorMessages.FieldIsEmpty, 
                            PXUIFieldAttribute.GetDisplayName< CreateStockItemParams.inventoryCD>(CreateStockItemDialog.Cache)));
                    return;
                }
                InventoryItemMaint maint = PXGraph.CreateInstance<InventoryItemMaint>();
                var newItem = new InventoryItem();
                newItem.InventoryCD = itemParams.InventoryCD;
                newItem = maint.Item.Insert(newItem);
                newItem.ItemClassID = Base.itemclass.Current.ItemClassID;
                maint.Item.Update(newItem);
                throw new PXRedirectRequiredException(maint, "New Stock Item");
            }
            protected void CreateStockItemParams_InventoryCD_FieldSelecting(PXCache sender, PXFieldSelectingEventArgs e)
            {
                e.IsAltered = true;
                object ret = e.ReturnValue;
                PXDimensionAttribute restoreCombo = null;
                foreach (PXEventSubscriberAttribute attr in sender.Graph.Caches[typeof(InventoryItem)]
                    .GetAttributesReadonly<InventoryItem.inventoryCD>())
                {
                    if (attr is PXDimensionAttribute)
                    {
                        if (((PXDimensionAttribute)attr).ValidComboRequired)
                        {
                            ((PXDimensionAttribute)attr).ValidComboRequired = false;
                            restoreCombo = (PXDimensionAttribute)attr;
                            break;
                        }
                    }
                }
                sender.Graph.Caches[typeof(InventoryItem)].
                    RaiseFieldSelecting<InventoryItem.inventoryCD>(null, ref ret, true);
                if (restoreCombo != null)
                {
                    restoreCombo.ValidComboRequired = true;
                }
                e.ReturnState = ret;
            }
            protected void CreateStockItemParams_InventoryCD_FieldVerifying(PXCache sender, PXFieldVerifyingEventArgs e)
            {
                object val = e.NewValue;
                sender.Graph.Caches[typeof(InventoryItem)].RaiseFieldVerifying<InventoryItem.inventoryCD>(null, ref val);
                var item = (InventoryItem)PXSelect<InventoryItem, Where<InventoryItem.inventoryCD, Equal<Required<InventoryItem.inventoryCD>>>>.SelectWindowed(Base, 0, 1, val);
                if (item != null)
                {
                    throw new PXSetPropertyException("Stock Item with Inventory ID {0} already exists.",
                        sender.Graph.Caches[typeof(InventoryItem)].GetValueExt<InventoryItem.inventoryCD>(item));
                }
                e.NewValue = val;
            }
        }
