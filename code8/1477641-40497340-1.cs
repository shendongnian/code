    protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // Check the type of Row if necessary 
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Do some processing here, in your case you can add onClick event handling for example
            e.Row.Attributes.Add("onclick" /* Your event handler here */);
    
            
           
        }
    }
