    private SizeF Measure(string Data)
    {
        using (var BMP = new Bitmap(1, 1))
        {
            using (Graphics G = Graphics.FromImage(BMP))
            {
                return G.MeasureString(Data, new Font("segoe ui", 11, FontStyle.Regular));
            }
        }
    }
