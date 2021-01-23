    using System.Drawing.Imaging;
    void PDF_To_Image(string pdf)
    {
       var doc = new Spire.Pdf.PdfDocument();
       doc.LoadFromFile(pdf);
                
       //This int is used to get the page count for each document 
       int pagecount = doc.Pages.Count;
    
       //With the int pagecount we can create as may screenshots as there are pages in the document
       for (int index = 0; index < pagecount; index++)
       {
          //render the image created
          var image = doc.SaveAsImage(index, Spire.Pdf.Graphics.PdfImageType.Bitmap);
    
          //save the created screenshot temporerlay as a png + number (count)
          image.Save(@"C:\Users\chnikos\Desktop\Test\output" + index.ToString("000") + ".png", ImageFormat.Png);
       }
    }
