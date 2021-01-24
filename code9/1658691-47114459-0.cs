    private System.Object _synchLock = new System.Object();
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {   
        lock(_synchLock)
        {
           if (e.KeyCode == Keys.Up && Player2Y > 0)
           {
               Player2Y -= 5;
               Invalidate();
           }
           if (e.KeyCode == Keys.W && Player1Y > 0)
           {
               Player1Y -= 5;
               Invalidate();
           }
        } 
    }
