    private stattic bool CheckUplodedImage()
    {
        bool return = false;
        try
        {
            PictureBox imageControl = new PictureBox();
            imageControl.Width = 60;
            imageControl.Height = 60;
     
            Bitmap image = new Bitmap("Images/brick_wall.jpg");
            imageControl.Image = (Image)image;
     
            Controls.Add(imageControl);
            return true;
       }
       catch(Exception ex)
       {
         return false;
       }
    }
