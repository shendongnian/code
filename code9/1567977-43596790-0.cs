    System.Web.UI.WebControls.Image sortArrow = new System.Web.UI.WebControls.Image();
    private void addSortImages()
    {
        int columnIndex = 0;
        //set the image url
        sortArrow.ImageUrl = "~/images/asc.png";
        if (mySortDirection == SortDirection.Descending)
        {
            sortArrow.ImageUrl = "~/images/desc.png";
        }
        //check for rows in the gridview
        if (GridView1.Rows.Count > 0)
        {
            //loop all the columns
            foreach (DataControlFieldHeaderCell cell in GridView1.HeaderRow.Cells)
            {
                if (cell.ContainingField.SortExpression == mySortExpression)
                {
                    columnIndex = GridView1.HeaderRow.Cells.GetCellIndex(cell);
                }
            }
            //add the image to the correct header cell
            GridView1.HeaderRow.Cells[columnIndex].Controls.Add(sortArrow);
        }
    }
