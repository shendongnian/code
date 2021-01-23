    protected void  protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostBack)
       {
          BindCategorySearch();
       }
    
    }
    
    protected void BindCategorySearch()
    {
       // Fill your ddlCategorySearch here
    }
    
    protected void ddlCategorySearch_SelectedIndexChanged(object sender, EventArgs e) 
        {
        	try
        	{
        		BindSubCategory();
        	}
        	catch (Exception ex)
        	{
        
        	}
        }
        
        protected void BindSubCategory()
        {
        	try
        	{
        		int categoryID = Convert.ToInt32(ddlCategorySearch.SelectedValue);
        		//For Example select * from SubCategory where CategoryID = categoryID
        		List<SubCategory> listSubcategories = new List<SubCategory>();
        		//Fill your listCategory on base of categoryID
        
        		ListItem li = new ListItem();
        		li.Text = "--Select Sub Category--";
        		li.Value = "0";
        		li.Selected = true;
        		ddlSubCategories.Items.Insert(0, li);
        	}
        	catch (Exception ex)
        	{
        		throw;
        	}
        }
