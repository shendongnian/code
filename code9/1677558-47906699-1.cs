    private async void Game_Screen_KeyDown(object sender, KeyEventArgs e)
    {
        for (int i = 0; i < 500; i++)
        {
            if (e.KeyCode == Keys.Left)
            {
                cannonBox.Location = new Point(cannonBox.Left - 2, cannonBox.Top); //Changes location of cannonBox to a new location to the left
                await Task.Delay(10); //Delays the movement by couple milliseconds to stop instant movement
            }
            if (e.KeyCode == Keys.Right)
            {
                cannonBox.Location = new Point(cannonBox.Left + 2, cannonBox.Top); //Changes location of cannonBox to a new location to the right
                await Task.Delay(10); //Delays the movement by couple milliseconds to stop instant movement
            }
            if (e.KeyCode == Keys.Up)
            {
                createLaser(); //Calls the method whenever Up arrow key is pressed
            }
        }
    }
