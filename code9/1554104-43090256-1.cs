    public void btnSearch_Click(object sender, EventArgs e)
    {
        pleaseWait.ShowDialog();
        backgroundWorker1.RunWorkerAsync();
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        try
        {
            this.TestDataTableAdapter.Fill(this.TesteDataData.TestDataTable, txtHotName.Text, ((System.DateTime)(System.Convert.ChangeType(txtDepartFrom.Text, typeof(System.DateTime)))), ((System.DateTime)(System.Convert.ChangeType(txtDepartTo.Text, typeof(System.DateTime)))), ((System.DateTime)(System.Convert.ChangeType(txtBookFrom.Text, typeof(System.DateTime)))), ((System.DateTime)(System.Convert.ChangeType(txtBookTo.Text, typeof(System.DateTime)))));
            
        }
        catch (System.Exception exc)
        {
            //You can't show a messagebox here,as it is not in the UI thread
        }
    }
 
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        pleaseWait.Close();
        int RowC = TestDataTableDataGridView.RowCount;
        if (RowC == 0)
        {
                MessageBox.Show(GlobVar.NoResults, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }
