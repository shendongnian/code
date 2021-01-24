     using System;
     using System.Collections.Generic;
     using System.Linq;
     using System.Text;
     using System.Threading.Tasks;
     using tessnet2;
     using System.Drawing;
     using System.Drawing.Drawing2D;
     using System.Drawing.Imaging;
     using System.IO;
     namespace ConsoleApplication2
     {
    class Program
    {
        static void Main(string[] args)
        {
            var image = new Bitmap(@"D:\Python\download.jpg");
            tessnet2.Tesseract ocr = new tessnet2.Tesseract();
            ocr.Init(@"C:\Program Files (x86)\Tesseract-OCR\tessdata", "eng",false);
            List<tessnet2.Word> result = ocr.DoOCR(image, Rectangle.Empty);
            foreach (tessnet2.Word word in result)
            {
                Console.WriteLine("{0} : {1}",word.Confidence,word.Text);
               
            }
            Console.Read();
        }
    }
    }
