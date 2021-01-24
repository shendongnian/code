    namespace WindowsFormsApplication10
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string path1 = @"C:\work\test.bmp";
            string path2 = @"C:\work\test2.bmp";
            WindowsFormsApplication10.ImageProcessing image = new WindowsFormsApplication10.ImageProcessing(path1);
            int time_of_processing = image.Grayscale();
            image.SaveTo(path2);
        }
    }
    public class ImageProcessing
    {
        Bitmap image;
        public ImageProcessing(string path)
        {
            image = new Bitmap(path);
        }
        public int Grayscale()
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    int grayScale = (int)((pixelColor.R * 0.21) + (pixelColor.G * 0.72) + (pixelColor.B * 0.07));
                    Color newColor = Color.FromArgb(grayScale, grayScale, grayScale);
                    image.SetPixel(x, y, newColor);
                }
            }
            time.Stop();
            TimeSpan ts = time.Elapsed;
            int milliseconds = ts.Milliseconds + (ts.Seconds * 1000);
            return milliseconds;
        }
        public void SaveTo(string path)
        {
            image.Save(path);
        }
    }
    }
