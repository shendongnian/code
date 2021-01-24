    var tableQuery = new TableQuery<MyDataEntity>().Where(
																 TableQuery.CombineFilters(
																	TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, itemPartitionKey),
																	TableOperators.And,
																	TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, itemRowKey)));
	var myDataEntities = table.ExecuteQuery(tableQuery).ToList();
    if (myDataEntities.Count == 0)
    {
        TableOperation inserOperation = TableOperation.Insert(loadMyDataItem);
        table.Execute(insertOperation);
    }
