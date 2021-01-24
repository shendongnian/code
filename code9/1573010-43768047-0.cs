    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //cast the row back to a datarowview
            DataRowView row = e.Row.DataItem as DataRowView;
            Image image = new Image();
            image.ImageUrl = @"/_layouts/15/images/Project/" + row["imageNameColumn"].ToString();
            //add the image to the gridview
            e.Row.Cells[0].Controls.Add(image);
        }
    }
