    // Note: Your load method may have a different name.
    private void Form2_Load(object sender, EventArgs e)
    {
        this.StartNewGame();
    }
    
    private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        if (MessageBox.Show("Continue?", "Continue?", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            this.StartNewGame();
        }
    }
    
    private void StartNewGame()
    {
        // Your game form may have a different name so change this to that name
        var gameForm = new Form2();
        gameForm.FormClosed += GameForm_FormClosed;
        gameForm.Show();
    }
