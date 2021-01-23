    protected void btnGenerateBarCode_Click(object sender, System.EventArgs e)
    {
        var codabar = new ZXing.BarcodeWriter();
        codabar.Options = options;
        codabar.Format = ZXing.BarcodeFormat.CODE_128;
        for (int i = 1000; i < 2000; i++)
            {
                using (Bitmap bitMap = new Bitmap(codabar.Write(i.ToString())))
                {
                    //  Here create the image control
					System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] byteImage = ms.ToArray();
                        Convert.ToBase64String(byteImage);
                        imgBarCode.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(byteImage);
                    }
					//the placeholder control on the page
                    plBarCode.Controls.Add(imgBarCode);
                }
            }
    }
