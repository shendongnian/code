    INVENTORY
    .GroupBy(inv => inv.BASE_QTY_PER_UNIT)
    .Select(invGroup => new 
    {
        GrossWeight = invGroup.Sum(inv => inv.RECEIVED_QTY),
    	BaseQuantityPerUnit = invGroup.Key
    })
    .AsEnumerable()
    .Select(anony => new
    {
    	GrossWeight = anony.GrossWeight / anony.BaseQuantityPerUnit
    })
