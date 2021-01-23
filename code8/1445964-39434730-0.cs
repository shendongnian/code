      string code = txtCode.Text;
    QRCodeGenerator qrGenerator = new QRCodeGenerator();
    QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
    imgBarCode.Height = 150;
    imgBarCode.Width = 150;
    using (Bitmap bitMap = qrCode.GetGraphic(20))
    {
        using (MemoryStream ms = new MemoryStream())
        {
            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] byteImage = ms.ToArray();
            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
        }
        plBarCode.Controls.Add(imgBarCode);
    }
