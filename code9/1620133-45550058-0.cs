    var queryMaterialized = itemsListFromDbQuery.FirstOrDefault();
    
    if (queryMaterialized != null)
    {
    	tempItemsList.Add(new ItemModel
    	{
    		FieldOne = queryMaterialized.FieldOne,
    		FieldTwo = queryMaterialized.FieldTwo ?? 0
    	});
    }
