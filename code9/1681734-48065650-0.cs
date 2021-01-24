    protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
               if (ddl.SelectedItem.Value == "1")
               {
                    txt_NY.ReadOnly = false; //set to false to make it editable
                    txt_Brooklyn.ReadOnly = true; //true to grey out
               }
               
               elseif (ddl.SelectedItem.Value == "2")
               {
                    txt_Brooklyn.ReadOnly = false;
                    txt_NY.ReadOnly = true;
               }
     
        }
