    public DataTable ChildrenOf(string parent, DataTable dtFolders)
    {
    	return dtFolders.AsEnumerable()
    		.Where(row => row.Field<String>("FolderId") == parent)
    		.CopyToDataTable();
    }
