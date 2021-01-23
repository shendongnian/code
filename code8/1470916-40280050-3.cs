    using System.Drawing.Imaging;
    string Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    //This one is with Spire.Pdf
    void PDF_To_Image(string pdf)
    {
       var doc = new Spire.Pdf.PdfDocument();
       doc.LoadFromFile(pdf);
                
       //This int is used to get the page count for each document 
       int pagecount = doc.Pages.Count;
    
       //With the int pagecount we can create as many screenshots as there are pages in the document
       for (int index = 0; index < pagecount; index++)
       {
          //render the image created
          var dpiX = 75;
          var dpiY = 75;
          var image = doc.SaveAsImage(index, Spire.Pdf.Graphics.PdfImageType.Bitmap, dpiX, dpiY);
    
          //save the created screenshot temporerlay as a png + number (count)
          image.Save(Desktop + @"\Test\output\" + index.ToString("000") + ".png", ImageFormat.Png);
       }
    }
    //This one is with Aspose.Pdf & xps2img.
    //Aspose.Pdf converts the Pdf document to Xps format..
    //xps2img creates images from the xps file..
    void PDF_To_Image2(string pdf)
    {
       var doc = new Aspose.Pdf.Document(pdf);
       var saveOptions = new Aspose.Pdf.XpsSaveOptions();
       doc.Save("Preview.xps", saveOptions);
    
       xps2img.Parameters pp = new xps2img.Parameters();
       pp.Dpi = 300;
       pp.ImageType = xps2img.ImageType.Png;
       pp.RequiredSize = new System.Drawing.Size((int)doc.PageInfo.Width, (int)doc.PageInfo.Height);
       pp.ImageOptions = xps2img.ImageOptions.Default;
       var img3 = xps2img.Xps2Image.ToBitmap("Preview.xps", pp).ToList();
    
    
       //This int is used to get the page count for each document 
       int pagecount = img3.Count;
    
       //With the int pagecount we can create as many screenshots as there are pages in the document
       for (int index = 0; index < pagecount; index++)
       {
          img3[index].Save(Desktop + @"\Test\Output\" + index.ToString("000") + ".png", ImageFormat.Png);
       }
    }
