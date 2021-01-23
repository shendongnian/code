    private void ShowImage()
    {
        Graphics g = pbImage.CreateGraphics();
        for (int x = 0; x < _bmp.Width; x++)
        {
            for (int y = 0; y < _bmp.Height; y++)
            {
                Color c = _bmp.GetPixel(x, y);
                if (pbImage.InvokeRequired)
                {
                    var x1 = x;
                    var y1 = y;
                    pbImage.BeginInvoke((Action) (() =>
                    {
                        g.FillRectangle(new SolidBrush(c), x1, y1, 1, 1);
                    }));
                }
                else
                {
                    g.FillRectangle(new SolidBrush(c), x, y, 1, 1);
                }
                System.Threading.Thread.Sleep(1);
            }
        }
    }
