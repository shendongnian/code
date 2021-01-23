    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;
    using System.IO;
    
    namespace JeremyThompsonLabs
    {
        public class Screenshot
        {
            public static string TakeScreenshotReturnFilePath()
            {
                int screenLeft = SystemInformation.VirtualScreen.Left;
                int screenTop = SystemInformation.VirtualScreen.Top;
                int screenWidth = SystemInformation.VirtualScreen.Width;
                int screenHeight = SystemInformation.VirtualScreen.Height;
    
                // Create a bitmap of the appropriate size to receive the screenshot.
                using (Bitmap bitmap = new Bitmap(screenWidth, screenHeight))
                {
                    // Draw the screenshot into our bitmap.
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(screenLeft, screenTop, 0, 0, bitmap.Size);
                    }
    
                    var uniqueFileName = Path.Combine(System.IO.Path.GetTempPath(), Path.GetRandomFileName().Replace(".", string.Empty) + ".jpeg");
                    try
                    {
                        bitmap.Save(uniqueFileName, ImageFormat.Jpeg);
                    }
                    catch (Exception ex)
                    {
                        return string.Empty;
                    }
                    return uniqueFileName;
                }
            }
            
        }
    }
