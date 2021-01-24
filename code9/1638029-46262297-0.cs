    // check if GridView is not empty
    if (GridView1.Rows.Count != 0)
    {
        string total = ((Label)GridView1.FooterRow.FindControl("16")).Text;
        LabelOutside.Text = total;
    }
 
    
