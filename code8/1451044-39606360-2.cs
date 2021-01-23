    public static Bitmap DrawNormalizedAudio(List<float> data, Color foreColor, Color backColor, Size imageSize, string imageFilename)
    {
        Bitmap bmp = new Bitmap(imageSize.Width, imageSize.Height);
        int BORDER_WIDTH = 0;
        float width = bmp.Width - (2 * BORDER_WIDTH);
        float height = bmp.Height - (2 * BORDER_WIDTH);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.Clear(backColor);
            Pen pen = new Pen(foreColor);
            float size = data.Count;
            for (float iPixel = 0; iPixel < width; iPixel += 1)
            {
                // determine start and end points within WAV
                int start = (int)(iPixel * (size / width));
                int end = (int)((iPixel + 1) * (size / width));
                if (end > data.Count)
                    end = data.Count;
                float posAvg, negAvg;
                averages(data, start, end, out posAvg, out negAvg);
                float yMax = BORDER_WIDTH + height - ((posAvg + 1) * .5f * height);
                float yMin = BORDER_WIDTH + height - ((negAvg + 1) * .5f * height);
                g.DrawLine(pen, iPixel + BORDER_WIDTH, yMax, iPixel + BORDER_WIDTH, yMin);
            }
        }
        bmp.Save(imageFilename);
        bmp.Dispose();
        return null;
    }
    private static void averages(List<float> data, int startIndex, int endIndex, out float posAvg, out float negAvg)
    {
        posAvg = 0.0f;
        negAvg = 0.0f;
        int posCount = 0, negCount = 0;
        for (int i = startIndex; i < endIndex; i++)
        {
            if (data[i] > 0)
            {
                posCount++;
                posAvg += data[i];
            }
            else
            {
                negCount++;
                negAvg += data[i];
            }
        }
        posAvg /= posCount;
        negAvg /= negCount;
    }
