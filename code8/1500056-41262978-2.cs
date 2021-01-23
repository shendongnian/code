    public Bitmap(Image original, int width, int height) : this(width, height) {
        Graphics g = null;
        try {
            g = Graphics.FromImage(this);
            g.Clear(Color.Transparent);
            g.DrawImage(original, 0, 0, width, height);
        }
        finally {
            if (g != null) {
                g.Dispose();
            }
        }
    }
