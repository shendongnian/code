    protected void PerformLongRunningODBCQuery()
    {
        // ...long running ODBC query stuff. 
    }
    public void doQuery1(object source, ElapsedEventArgs e)
    {
        PerformLongRunningODBCQuery();
    }
    private void btnQuery1Start_Click(object sender, EventArgs e)
    {
        query1Timer.Interval = Convert.ToInt32(txtQuery1Interval.Text) * 1000;
        query1Timer.Enabled = true;
        PerformLongRunningODBCQuery();
    }
