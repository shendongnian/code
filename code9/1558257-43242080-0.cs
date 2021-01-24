    private void frmPingPong_KeyDown(object sender, KeyEventArgs e) 
    {
    
     var maxY = 298;
     var minY = 0;
    
     if (e.KeyCode == Keys.W) 
     {
      var newY = picSchlägerRechts.Location.Y - ms;
    
      if (newY < minY) 
      {
       newY = minY;
      }
      picSchlägerRechts.Location = new Point(picSchlägerRechts.Location.X, newY);
     }
     else if (e.KeyCode == Keys.S) 
     {
      var newY = picSchlägerRechts.Location.Y + ms;
    
      if (newY > maxY) 
      {
       newY = maxY;
      }
      picSchlägerRechts.Location = new Point(picSchlägerRechts.Location.X, newY);
     }
    }
