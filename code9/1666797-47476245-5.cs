    private async void btn_Click(object sender, EventArgs e)
    {
        Database db = new Database();
        await Task.Run(() => SaveUsername(txtUsername.Text));    
        new Form2().Show();
    }
