    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //cast the row back to a datarowview
            DataRowView row = e.Row.DataItem as DataRowView;
            //get the extension from the file name
            string extension = Path.GetExtension(row["Name"].ToString().ToLower());
            //show the correct icon
            if (extension == ".pdf")
            {
                ib.ImageUrl = "/images/pdf.GIF";
            }
            else
            {
                ib.ImageUrl = "/images/unknown.GIF";
            }
        }
    }
