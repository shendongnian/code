    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == Keys.Up)
        {
            BindingContext[dataGridView1.DataSource, dataGridView1.DataMember].Position -= 1;
            return true;
        }
        if (keyData == Keys.Down)
        {
            BindingContext[dataGridView1.DataSource, dataGridView1.DataMember].Position += 1;
            return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }
