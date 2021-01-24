    private void button4_Click(object sender, EventArgs e)
    {
        OpenFileDialog openb = new OpenFileDialog();
        if (openb.ShowDialog() == DialogResult.OK)
        {
            var name = openb.FileName;
            String filename = DialogResult.ToString();
            excelApp = new Excel.Application();
            excelApp.Visible = true;
        }
