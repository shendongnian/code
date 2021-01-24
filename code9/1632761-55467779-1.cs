      protected void btnGenerate_Click(object sender, EventArgs e)
        {
            string barCode = txtCode.Text;
            //testbar.Text = txtCode.Text;
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            using (Bitmap bitMap = new Bitmap(barCode.Length * 28, 90))
            {
                using (Graphics graphics = Graphics.FromImage(bitMap))
                {
                    var fonts = new PrivateFontCollection();
                    fonts.AddFontFile(Server.MapPath("~/font/IDAutomationHC39M.ttf"));
                    Font oFont = new Font((FontFamily)fonts.Families[0], 17f);
                    //Font oFont = new Font("IDAutomationHC39M", 10,FontStyle.Regular,GraphicsUnit.Pixel);
                    PointF point = new PointF(2f, 2f);
                    SolidBrush blackBrush = new SolidBrush(Color.Black);
                    SolidBrush whiteBrush = new SolidBrush(Color.White);
                    graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                    graphics.DrawString("*" + barCode + "*", oFont , blackBrush, point);
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();
                    Convert.ToBase64String(byteImage);
                    imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                }
                plBarCode.Controls.Add(imgBarCode);
            }
        }
