    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        gcDamageItems.BeginInvoke(new Action(() =>
        {
            gcDamageItems.ForceInitialize();
            gvDamageItems.MoveFirst();
            gvDamageItems.FocusedColumn = gvDamageItems.VisibleColumns[0];
            gvDamageItems.ShowEditor();
        }));
    }
