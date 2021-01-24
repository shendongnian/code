    private async void btn_Click(object sender, EventArgs e)
    {
        Database db = new Database();
        await db.SaveUsernameAsync(txtUsername.Text);
        new Form2().Show();
    }
    class Database
    {
        public async Task  SaveUsername(string username)
        {
            Connect(); //Connection to database
            //Some lines to save username in database
            ....
            await db.SaveAsync();
        }
    }
