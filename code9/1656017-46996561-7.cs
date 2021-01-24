    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Windows.Forms;    
    
    namespace BwImgSO
    {
        class Program
        {
            static void Main(string[] args)
            {
                Bitmap bitmap = new Bitmap(@"C: \Users\me\Desktop\color.jpg");
                Bitmap grayScaleBitmap = GrayScale(bitmap);
                string outputFileName = @"C: \Users\me\Desktop\bw.jpg";
                using (MemoryStream memory = new MemoryStream())
                {
                    using (FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite))
                    {
                        grayScaleBitmap.Save(memory, ImageFormat.Jpeg);
                        byte[] bytes = memory.ToArray();
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
            }
    
            private static Bitmap GrayScale(Bitmap bmp)
            {
                //get image dimension
                int width = bmp.Width;
                int height = bmp.Height;
                int threshold = 128;
    
                //color of pixel
                System.Drawing.Color p;
    
                //grayscale
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        //get pixel value
                        p = bmp.GetPixel(x, y);
    
                        //extract pixel component ARGB
                        int a = p.A;
                        int r = p.R;
                        int g = p.G;
                        int b = p.B;
    
                        //find average, transform to b/w value
                        //int bw = (r + g + b) / 3 / 128; // or 384 if you prefer
                        int wb = (r + g + b) / 3; // avg: [0-255]
                        //transform avg to [0-1] using threshold
                        wb = (wb >= threshold) ? 1 : 0;  
                        //set new pixel value
                        bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(a, bw*255, bw*255, bw*255));
                    }
                }
    
                return bmp;
            }
        }
    }
