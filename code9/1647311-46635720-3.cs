    private async void btnMigrate_Click(object sender, EventArgs e)
    {
        SetLabelText(lblStatus, "Migrating data....");
        
        await Task.Run(()=> Migrate());
        
        SetLabelText(lblStatus, "Migration complete.");
    }
    private void SetLabelText(Label label, string text)
    {
        if (label.InvokeRequired)
        {
            label.BeginInvoke((MethodInvoker) delegate() {label.Text = text;});    
        }
        else
        {
            label.Text = text; 
        }
    }
