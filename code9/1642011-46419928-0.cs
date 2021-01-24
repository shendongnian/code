    public void callAsPopup(System.Windows.Forms.Form  frm)
    {
        // sanity check to avoid crash on the Show call.
        if(frm == null)
            return;
        if(frm is  frmBatch)
            this.CenterToParent();
        this.Show();
    }
