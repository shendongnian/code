    //# Get copied data (image) from clipboard
    IDataObject data = Clipboard.GetDataObject();
    
    if (data.GetDataPresent(DataFormats.Dib))
    {
    	//# Make into C# bitmap
    	Bitmap image = (data.GetData(DataFormats.Bitmap,true) as Bitmap);
    	
    	//# Show in some PictureBox
    	//pbx.Image = image;
    	
    	//# Save to disk
    	image.Save("c:/test//encode_test1.jpg", System.Drawing.Imaging.ImageFormat.Jpeg );
    }
