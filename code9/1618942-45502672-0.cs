    bool IsSaving;
    private void FrmAddBase_KeyDown(object sender, KeyEventArgs e)
    {
            if (e.Control && e.KeyCode == Keys.N)
            {
                if (btnAdd.Enabled)
                {
                    btnAdd_ItemClick(null, null);
                }
            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                if (btnSave.Enabled)
                {
                    if(IsSaving) return;
                    IsSaving = true;
                    //I guess this is the save process, and its not threaded
                    btnSave_ItemClick(null, null);
                    IsSaving = false;
                }
            }
}
