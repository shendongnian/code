    public event EventHandler AfterShwon;
    protected override void OnShown(EventArgs e)
    {
         base.OnShow(e);
         OnAfterShown(e);
    }
    protected virtual void OnAfterShown(e)
    {
         AfterShwon?.Invoke(this, e);
    }
