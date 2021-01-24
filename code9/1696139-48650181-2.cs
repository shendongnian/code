        class Program
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern int SystemParametersInfo(int uAction,
               int uParam, string lpvParam, int fuWinIni);
    
            private static readonly int MAX_PATH = 260;
            private static readonly int SPI_GETDESKWALLPAPER = 0x73;
            private static readonly int SPI_SETDESKWALLPAPER = 0x14;
            private static readonly int SPIF_UPDATEINIFILE = 0x01;
            private static readonly int SPIF_SENDWININICHANGE = 0x02;
    
            static string GetDesktopWallpaper()
            {
                string wallpaper = new string('\0', MAX_PATH);
                SystemParametersInfo(SPI_GETDESKWALLPAPER, (int)wallpaper.Length, wallpaper, 0);
                return wallpaper.Substring(0, wallpaper.IndexOf('\0'));
            }
    
            static void SetDesktopWallpaper(string filename)
            {
                SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, filename,
                    SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
            }
            static void Main()
            {
                Console.WriteLine("Enter name:");
                //should be like - C:\img.jpg
                SetDesktopWallpaper(Console.ReadLine());
              
            }    
        }
