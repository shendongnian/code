    protected void PreventErrorOnbinding(object sender, EventArgs e)
    {
                 
        DropDownList theDropDownList = (DropDownList)sender;
        theDropDownList.DataBinding -= new EventHandler(PreventErrorOnbinding);
    
        //Allow a combination of databind and appended data.
        theDropDownList.AppendDataBoundItems = true;
                 
        //Tries to bind the data, if it doesn't exist, it will add it in the selection list.
        try
        {
            theDropDownList.DataBind();
        }
        catch (ArgumentOutOfRangeException)
        {
            var dv = new DataView();
            var dt = new DataTable();
            var ds = new SqlDataSource();
    
            //Uses the source data to add the missing value
            dv = DSProjects.Select(DataSourceSelectArguments.Empty) as DataView;
            dt = dv.ToTable();
    
            string strField = theDropDownList.ID.Substring(theDropDownList.ID.IndexOf("db")+2, theDropDownList.ID.Length - (theDropDownList.ID.IndexOf("db") + 2)); //Couldn't find a way to dynamically reference the DataBind fieldname.
            string strValue = dt.Rows[0][strField].ToString();  
    
            //Add the value pair.
            ListItem liValue = new ListItem(strValue, strValue);
    
            theDropDownList.Items.Add(liValue);
            theDropDownList.SelectedValue = strValue;
        }
    }
