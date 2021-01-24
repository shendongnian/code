    protected void repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
    			
    	if (e.CommandName == "Visit")
    	{
    		var rowIndex = (int)e.CommandArgument;
            //Here I am assuming that your data source is a DataTable
    		var row = ((DataTable)repeater.DataSource).Rows[0];
    		var newsID = row.Field<int>("newsID");
    		var categoriesID = row.Field<int>("fk_categories_id");
    
    		Response.Redirect($"Article.aspx?category_id={categoriesID}& amp;news_id={categoriesID}");
    		Response.Write($"Do something with {e.CommandArgument}");
    	}
    
    }
