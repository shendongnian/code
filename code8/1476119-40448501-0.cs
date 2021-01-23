    public void CreateImgObj(object sender)
    {
        try
        {
            FileStream fs = File.Open((string)sender, FileMode.Open);
            Bitmap dImg = new Bitmap(fs);
            MemoryStream ms = new MemoryStream();
            dImg.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            BitmapImage bi_img = new BitmapImage();
            bi_img.BeginInit();
            bi_img.StreamSource = new MemoryStream(ms.ToArray());
            bi_img.EndInit();
            evt_send_img(bi_img);
        }
        catch (Exception e)
        {
            evt_error(e);
        }
    }
