    private static Form1 f1;
    private void button1_Click(object sender, EventArgs e)
    {
        if (f1 == null)
        {
            f1 = new Form1();
        }
        
        DataTable dt1 = new DataTable();
        f1.dataGridView2.DataSource = dt1;
        dt1.Columns.Add("MessageID", typeof(string));
        dt1.Columns.Add("Name", typeof(string));
        dt1.Columns.Add("Number", typeof(string));
        DataRow dr = dt1.NewRow();
        dr["MessageID"] = IDtext.Text; ;
        dr["Name"] = nameText.Text;
        dr["Number"] = numberText.Text;
        dt1.Rows.Add(dr);
        f1.Show();
        f1.BringToFront();
    }
