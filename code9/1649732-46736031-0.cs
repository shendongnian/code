    private void btnAdd_Click(object sender, EventArgs e)
    {
        int x;
        int y;
        if(!int.TryParse(txtIn1.Text, out x) || !int.TryParse(txtIn2.Text, out y))
            MessageBox.Show("Parse failed !");          
    }
