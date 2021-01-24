    private Product GetSelectedProduct()
    {
        DataView productsTable = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        productsTable.RowFilter = string.Format("ProductID = '{0}'", ddlProducts.SelectedValue);
    	
    	if (productsTable.Count > 0)
    	{
    		DataRowView row = (DataRowView)productsTable[0];
    
    		Product p = new Product();
    		p.ProductID = row["ProductID"].ToString();
    		p.Name = row["Name"].ToString();
    		p.ShortDescription = row["ShortDescription"].ToString();
    		p.LongDescription = row["LongDescription"].ToString();
    		p.UnitPrice = (decimal)row["UnitPrice"];
    		p.ImageFile = row["ImageFile"].ToString();
    		return p;
    	}
    	else
    	{
            // Or throw an exception, if your logic dictates that this method SHOULD return a record.
    		return null;
    	}
    }
