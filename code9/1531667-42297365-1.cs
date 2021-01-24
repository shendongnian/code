    private void button1_Click(object sender, EventArgs e)
    {
        formPass pass = new formPass();
        pass.ShowDialog();
        if(AdminIsConfirmed)
        {
             this.Hide();
        }
    }
