    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
            {
                if (e.CommandName == "Item") 
                {
         
                    int index= Convert.ToInt32(e.CommandArgument); 
         
                   Response.Redirect("~/SelectedCatg.aspx?id=" + index);
         
                    
                }
            }
