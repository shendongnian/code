    public Size screenSize;
    private void Game_Screen_Load(object sender, EventArgs e)
    {
        screenSize = this.Size;
    }
    
    
    
    private void Game_Screen_KeyDown(object sender, KeyEventArgs e)
    {
        for (int i = 0; i < 100; i++)
        {
    
            if (lives != 0)
            {
                if (e.KeyCode == Keys.Left)
                {
    
                    if (cannonBox.Location.X < 0)
                    {
                        cannonBox.Location = new Point(cannonBox.Left = this.Width, cannonBox.Top);
                    }
    
                    cannonBox.Location = new Point(cannonBox.Left -= 2, cannonBox.Top); //Changes location of cannonBox to a new location to the left
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(10);
                }
    
                else
                if (e.KeyCode == Keys.Right)
                {
    
                    if (cannonBox.Location.X + cannonBox.Width > screenSize.Width)
                    {
                        cannonBox.Location = new Point(cannonBox.Left = 0 - cannonBox.Width, cannonBox.Top);
                    }
    
                    cannonBox.Location = new Point(cannonBox.Left + 2, cannonBox.Top); //Changes location of cannonBox to a new location to the right
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(10); //Delays the movement by couple milliseconds to stop instant movement
                }
            }
    
        }
    }
