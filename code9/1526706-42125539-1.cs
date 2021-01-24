    private void Form1_Load(object sender, EventArgs e)
    {
        this.usersTableAdapter.Fill(this.testDBDataSet.Users);
        DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
        dataGridView1.Columns.Insert(0, imageCol);
        dataGridView1.Columns[0].Name = "Image";
    }
    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        int userID = (int)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
        Bitmap img = new Bitmap(@"C:\Images\" + userID + ".jpg");    
        dataGridView1.Rows[e.RowIndex].Cells[0].Value = img;
    }
