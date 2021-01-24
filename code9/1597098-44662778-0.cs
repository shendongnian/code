    private void ChangePictureBoxSize(int newWidth, int newHeight)
    {
        // these will be negative if picturebox is getting bigger
        int changeInWidth = pictureBox1.Width - newWidth; 
        int changeInHeight = pictureBox1.Height - newHeight;
    
        // will shift left and up if picturebox is getting bigger
        int newX = pictureBox1.Location.X + (changeInWidth / 2); 
        int newY = pictureBox1.Location.Y + (changeInHeight / 2);
    
        pictureBox1.Location = new Point(newX, newY);
        pictureBox1.Size = new Size(newWidth, newHeight);
    }
