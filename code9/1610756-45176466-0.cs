    static public Color GetPixelColor(int x, int y, IntPtr hdc)
    {
        uint pixel = GetPixel(hdc, x, y);
        Color color = Color.FromArgb((int)(pixel & 0x000000FF),
                     (int)(pixel & 0x0000FF00) >> 8,
                     (int)(pixel & 0x00FF0000) >> 16);
        return color;
    }
    public static bool isCorrect(string path)
    {
        IntPtr hdc = GetDC(IntPtr.Zero);
        try
        {
            using (StreamReader sr = File.OpenText(path))
            {
                string result = "";
                string[] correctedResult;
                while ((result = sr.ReadLine()) != null)
                {
                    correctedResult = result.Split('|');
                    int X = Convert.ToInt32(correctedResult[0]);
                    int Y = Convert.ToInt32(correctedResult[1]);
                    int R = Convert.ToInt32(correctedResult[2]);
                    int G = Convert.ToInt32(correctedResult[3]);
                    int B = Convert.ToInt32(correctedResult[4]);
                    int maxDifference = Convert.ToInt32(correctedResult[5]);
                    Color c;
                    c = GetPixelColor(X, Y);
                    maxDifference /= 2;
                    if (R < c.R - maxDifference || R > c.R + maxDifference)
                    {
                        return false;
                    }
                    if (G < c.G - maxDifference || G > c.G + maxDifference)
                    {
                        return false;
                    }
                    if (B < c.B - maxDifference || B > c.B + maxDifference)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        finally
        {
            ReleaseDC(IntPtr.Zero, hdc);
        }
    }
    public static void Record(string name, int start_x, int start_y, int end_x, int end_y, int max_Difference)
    {
        string path = name + ".LOB";
    
        string result;
        Color pixel_Result;
        IntPtr hdc = GetDC(IntPtr.Zero);
        try
        {
            using (StreamWriter sw = new StreamWriter(path, append:true))
            {
                for (int x = start_x; x <= end_x; x++)
                {
                    for (int y = start_y; y <= end_y; y++)
                    {
                        pixel_Result = GetPixelColor(x, y, hdc);
                        result = x + "|" + y + "|" + pixel_Result.R + "|" + pixel_Result.G + "|" + pixel_Result.B + "|" + max_Difference;
                        sw.WriteLine(result);
                    }
                }
            }
        finally
        {
            ReleaseDC(IntPtr.Zero, hdc);
        }
    }
