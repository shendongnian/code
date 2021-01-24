    private void button3_Click( object sender, EventArgs e ) {
        open.DefaultExt = "jpg";
        open.ShowDialog();
        // Since you're returning the image path, we can grab it here
        String
            imageFilepath = DecryptPassword( open.FileName );
        // Create a new Bitmap with the image path returned from earlier
        Bitmap
            imageBitmap = new Bitmap( imageFilepath );
        // Set the Bitmap to your PictureBox
        pictureBox3.Image = (Image) imageBitmap;
    }
