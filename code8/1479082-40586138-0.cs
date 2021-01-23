    void testGridView_CopyingCellClipboardContent(object sender, GridViewCellClipboardEventArgs e)
    {
        if (grdName.CurrentCell != null && grdName.CurrentCell.Column == e.Cell.Column)
        {
            e.Cancel = false;
        }
        else
            e.Cancel = true;
    }
