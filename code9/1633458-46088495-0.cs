    private void TmrMainTimer_Tick(object sender, EventArgs e)
    {
      ...
      if (pBall.Top + pBall.Height > ClientSize.Height)
      {
        gameOver();
        MessageBox.Show("SORRY YOU LOSE!");
    
        // close the game form
        this.Close();
      } 
    }
