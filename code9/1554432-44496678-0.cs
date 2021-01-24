    protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
    {
       e.Cancel = !PageUtilities.CanNavigate(this, null);
       base.OnBackKeyPress(e);
    }
