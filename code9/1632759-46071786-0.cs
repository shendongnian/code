    public void generateBarcode(string id)
    {
                    int w = id.Length * 55;
        
                    // Create a bitmap object of the width that we calculated and height of 100
                    Bitmap oBitmap = new Bitmap(w, 100);
                    // then create a Graphic object for the bitmap we just created.
                    Graphics oGraphics = Graphics.FromImage(oBitmap);
                    // Now create a Font object for the Barcode Font
                    // (in this case the IDAutomationHC39M) of 18 point size
                    Font oFont = new Font("IDAutomationHC39M", 18);
                    // Let's create the Point and Brushes for the barcode
                    PointF oPoint = new PointF(2f, 2f);
                    SolidBrush oBrushWrite = new SolidBrush(Color.Black);
                    SolidBrush oBrush = new SolidBrush(Color.White);
                    // Now lets create the actual barcode image
                    // with a rectangle filled with white color
                    oGraphics.FillRectangle(oBrush, 0, 0, w, 100);
                    // We have to put prefix and sufix of an asterisk (*),
                    // in order to be a valid barcode
                    oGraphics.DrawString("*" + id + "*", oFont, oBrushWrite, oPoint);
                    // Then we send the Graphics with the actual barcode
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
        
                    using (System.IO.FileStream fs = System.IO.File.Open(Server.MapPath("~/img/barcodes/") + id + ".jpg", FileMode.Create))
                    {
                        oBitmap.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
        
                    }
                    oBitmap.Dispose();
                    imgbarcode.ImageUrl = "~/img/barcodes/"+id+".jpg";
    }
