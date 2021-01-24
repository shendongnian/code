    protected void mainDataGrid_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow objRow in mainDataGrid.Rows)
        {
            TableCell tcCheckCell = new TableCell();
            CheckBox chkCheckBox = new CheckBox();
            tcCheckCell.Controls.Add(chkCheckBox);
            objRow.Cells.AddAt(0, tcCheckCell);
        }
    }
