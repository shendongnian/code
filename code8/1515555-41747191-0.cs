	public List<string> GetTableNames(TableMetaData filterData)
	{
	    List<string> filteredNames = tableMetaData
	        .Where(table => (table.IsAuditTable == filterData.IsAuditTable)
	            && (table.IsSyncTable == filterData.IsSyncTable)
	            && (table.IsView == filterData.IsView)
				&& (filterData.ReferenceTableName == null ? true : table.ReferenceTableName == filterData.ReferenceTableName)
				&& (filterData.TableName == null ? true : table.TableName == filterData.TableName))
	        .Select(table => table.TableName).ToList();
	
	    return filteredNames;
	}
