    bool handle = true;
    private void gridView_CellEditEnded(object sender, GridViewCellEditEndedEventArgs e)
    {
        if (e.EditAction == GridViewEditAction.Commit && handle)
        {
            handle = false;
            gridView.CommitEdit();
            handle = true;
        }
    }
