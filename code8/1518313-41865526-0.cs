    private void doSomeThing() {
    try
        {
            ...
            //Code adding datasources to rpvCustomReport
            ...
            this.rpvCustomReport.RefreshReport(); //Causing the error.
            //NOTE: this.rpvCustomReport is instantiated in .Design.cs as
            //new Microsoft.Reporting.WinForms.ReportViewer();
            ...
        }
        catch (Exception ex)
        {
            HandleException(ex); //Custom function to handle exception
        }
    }
    private void btnOk_Click(object sender, EventArgs e)
    {
        this.doSomeThing();
    }
    private void rpvCustomReport_ReportRefresh(object sender, CancelEventArgs e)
    {
        this.doSomeThing();
    }
