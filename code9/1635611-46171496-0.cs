      protected void GridViewName_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                  //Hide the Textbox
                   TextBox txtboxtobehidden= 
                (TextBox)e.Row.FindControl("txtboxtobehidden");
                   txtboxtobehidden.Visible = false;    
                }
            }
            catch (Exception ex)
            {
               // your error Code
            }    
        }
