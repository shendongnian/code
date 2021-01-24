    public DataTable ChildrenOf(string parent, DataTable dtFolders)
    {
        DataTable result = new DataTable();
        try
        {
           if (dtFolders != null)
           {
              result = dtFolders.Clone();
              foreach (DataRow child in dtFolders.Rows)
              {
                if (child["FolderId"].ToString() == parent)
                {
                    result.Rows.Add(child.ItemArray);
                }
                if (child ["ParentId"]!=null && child ["ParentId"].ToString() == parent)
                {
                    result.Rows.Add(child.ItemArray);
                    parent =child.ItemArray.ToString();
                }
             }
           
        }
    }
    catch (Exception)
    {
        throw;
    }
    return result;
   
    }
 
