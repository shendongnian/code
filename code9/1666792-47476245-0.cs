    private Task async btn_Click(object sender, EventArgs e)
    {
        Database db = new Database();
        await db.SaveUsernameAsync(txtUsername.Text);
        new Form2().Show();
    }
    class Database
    {
        public Task async SaveUsername(string username)
        {
            Connect(); //Connection to database
            //Some lines to save username in database
            ....
            await db.SaveAsync();
        }
    }
