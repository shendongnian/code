    private int TimeToColorInMiliSeconds = 2000;
    private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        this.dataGridView1[e.ColumnIndex, e.RowIndex].Tag = DateTime.Now;
        Task.Run(() => this.ChangeCellBackground(e.ColumnIndex, e.RowIndex, Color.White, Color.IndianRed));
    }
    private void ChangeCellBackground(int col, int row, Color original, Color alert)
    {
        this.dataGridView1.BeginInvoke((MethodInvoker)delegate
        {
            this.dataGridView1[col, row].Style.BackColor = alert;
        });
        Thread.Sleep(this.TimeToColorInMiliSeconds);
        this.dataGridView1.BeginInvoke((MethodInvoker)delegate
        {
            DateTime lastChanged = (DateTime)(this.dataGridView1[col, row].Tag);
            DateTime timeNow = DateTime.Now;
            TimeSpan elapsed = timeNow - lastChanged;
            if (elapsed.TotalMilliseconds >= this.TimeToColorInMiliSeconds)
            {
                this.dataGridView1[col, row].Style.BackColor = original;
            }
        });
    }
