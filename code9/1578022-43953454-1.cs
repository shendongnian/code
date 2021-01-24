    var retryOrCancel = MessageBox.Show(
        text: "You Timed Out",
        caption: "Oops",
        buttons: MessageBoxButtons.RetryCancel,
        icon: MessageBoxIcon.Stop
    );
    
    switch (retryOrCancel)
    {
        case DialogResult.Cancel:
        this.Close();
        break;
        case DialogResult.Retry:
        StartGame();
        break;
    }
    private void start_game_button19_Click(object sender, EventArgs e)
    {
        StartGame();
    }
    private void StartGame() 
    {
        timer1.Enabled = true;
        timer1.Start();
    }
