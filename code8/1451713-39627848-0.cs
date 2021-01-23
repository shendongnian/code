    int width = 720;
    int height = 402;
    VideoFileWriter writer = new VideoFileWriter();
    writer.Open(@"C:\Temp\video.mp4", width, height, 25, VideoCodec.MPEG4, 1000000);
    Bitmap originalImage = new Bitmap(@"C:\Temp\myimage.jpg");
    Bitmap resizedImage = new Bitmap(originalImage, new Size(width, height));
    for (int i = 0; i < 250; i++)
    {
        writer.WriteVideoFrame(resizedImage);
    }
    writer.Close();
