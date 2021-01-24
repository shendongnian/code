    private void radGridView_RowEditEnded(object sender, GridViewRowEditEndedEventArgs e)
    {
        if (e.EditAction == GridViewEditAction.Cancel)
        {
            return;
        }
        if (e.EditOperationType == GridViewEditOperationType.Edit)
        {
            //Update the entry in the data base based on your logic.
        }
    }
