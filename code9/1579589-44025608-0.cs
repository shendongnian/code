    private bool _handle = true;
    private void dg2_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
    {
        if (_handle)
        {
            _handle = false;
            dg2.CommitEdit();
            var text = e.Row.Item as Skill;
            //...
            _handle = true;
        }
    }
