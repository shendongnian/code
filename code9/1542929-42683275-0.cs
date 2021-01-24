    IN401000WebRef.Content itemSumSchema = IN401000context.GetSchema();
    var itemSumCommands = new IN401000WebRef.Command[]
    {
        new IN401000WebRef.Value
        {
            LinkedCommand = itemSumSchema.Selection.InventoryID,
            Value = item[0]
        },
        new IN401000WebRef.Value
        {
            LinkedCommand = itemSumSchema.Selection.ExpandByLotSerialNumber,
            Value = "True"
        },
        itemSumSchema.InventorySummary.Warehouse,
        itemSumSchema.InventorySummary.Location,
        itemSumSchema.InventorySummary.OnHand,
        itemSumSchema.InventorySummary.EstimatedTotalCost,
        itemSumSchema.InventorySummary.LotSerialNumber
    };
    var serials = IN401000context.Submit(itemSumCommands);
