    if (dtItems != null)
                {
                    ImageButton imb = sender as ImageButton;
                    int rowIndex = Convert.ToInt32(imb.CommandArgument);
    
    
                    if (dtItems.Rows.Count > 0)
                    {
                        dtItems.Rows.Remove(dtItems.Rows[rowIndex]);
    
                        gdDyeNames.DataSource = dtItems;
                        gdDyeNames.DataBind();
    
                        lblEror.Text = "";
                        lblMsg.Text = "";
                        mpdelete.Hide();
    
                        if (dtItems.Rows.Count == 0)
                        {
                            createIntialGrid();
                        }
