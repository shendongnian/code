    using System.Drawing.Imaging;
    string Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
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
