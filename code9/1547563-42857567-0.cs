    private void panel1_Resize(object sender, EventArgs e)
    {
        ResizePb();
    }
    private void ResizePb()
    {
        //Make the pciturebox as wide as the panel, keep in mind the scrollbars
        pictureBox1.Width = panel1.Width - SystemInformation.VerticalScrollBarWidth - 5; 
        //Calculate the aspect ratio of the image based on its new width
        var aspect = (double)panel1.Width / pictureBox1.Image.Width;
        //Set height according to aspect ratio
        var height = Convert.ToInt32(aspect * pictureBox1.Image.Height);
        pictureBox1.Height = height;
    }
