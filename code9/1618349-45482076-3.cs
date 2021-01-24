    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        protected void Button1_Click(object sender, EventArgs e)
        {
            CompareImage();
        }
    
        private void CompareImage()
        {
            Bitmap image1;
            try
            {
                image1 = new Bitmap(Server.MapPath(@"~\Image\Panda.jpg"), true);
                OldImage.ImageUrl = "~/Image/Panda.jpg";
                int x, y;
    
    
                for (x = 0; x < image1.Width; x++)
                {
                    for (y = 0; y < image1.Height; y++)
                    {
                        if (y < 150)
                        {
                            Color pixelColor = image1.GetPixel(x, y);
                            Color newColor = Color.FromArgb(pixelColor.R, 25, 60);
                            image1.SetPixel(x, y, newColor);
                        }
                        else if (y >= 150 && y < 300)
                        {
                            Color pixelColor = image1.GetPixel(x, y);
                            Color newColor = Color.FromArgb(pixelColor.R, 200, 100);
                            image1.SetPixel(x, y, newColor);
                        }
                        else
                        {
    
                            Color pixelColor = image1.GetPixel(x, y);
                            Color newColor = Color.FromArgb(pixelColor.R, 100, 210);
                            image1.SetPixel(x, y, newColor);
    
                        }
                    }
                }
    
    
                //image1.Save(Server.MapPath(@"~\Image\xyz.jpg"), ImageFormat.Jpeg);
                image1.Save(AppDomain.CurrentDomain.BaseDirectory + "Image/xyz.jpg", ImageFormat.Jpeg);
                NewImage.ImageUrl = @"~/Image/xyz.jpg";
                Label1.Text = "Pixel format: " + image1.PixelFormat.ToString();
    
    
    
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    
    }
