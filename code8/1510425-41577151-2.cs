    class MyForm
    {
        Bitmap zoneDisplay;
        Bitmap zoneMap;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            zoneDisplay = (Bitmap)Image.FromFile(@"c:\temp\zonedisp.png"); // replace with actual path to file
            zoneMap = (Bitmap)Image.FromFile(@"c:\temp\zonemap.png");
            // put the display image into the picturebox (or whatever control displays it)
            pictureBox.Image = zoneDisplay;
        }
