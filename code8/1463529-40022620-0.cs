    var pictureBoxBitmap = new Bitmap(width, height, ....);
    picturebox1.Image = pictureBoxBitmap;
    picturebox1.SizeMode = PictureBoxSizeMode.StretchImage;
    using(Graphics pictureBoxGraphics = Graphics.FromImage(pictureBoxBitmap))  
    {
        if(cmd.DataReader.Read())
        {  
           var lob = cmd.ExecuteReader().GetOracleLob(0);
           using(var image = new Bitmap(lob))
           {
                pictureBoxGraphics.DrawImage(..... image);
                pictureBox1.Refresh();
           }
       }
    }
