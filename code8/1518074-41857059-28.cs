    private static Bitmap DeskewImageByIndividualChars(Bitmap bitmap)
    {
        IDictionary<Rectangle, Tuple<Bitmap, double>> characters = new CCL().Process(bitmap);
        Bitmap deskewedBitmap = new Bitmap(bitmap.Width, bitmap.Height, bitmap.PixelFormat);
        deskewedBitmap.SetResolution(bitmap.HorizontalResolution, bitmap.VerticalResolution);
        using (Graphics g = Graphics.FromImage(deskewedBitmap))
        {
            g.FillRectangle(Brushes.White, new Rectangle(Point.Empty, deskewedBitmap.Size));
            int baseLine = characters.Max(c => c.Key.Bottom);
            foreach (var character in characters)
            {
                int y = character.Key.Y;
                if (character.Key.Bottom != baseLine)
                {
                    y += (baseLine - character.Key.Bottom - 1);
                }
                using (Bitmap characterBitmap = RotateImage(character.Value.Item1, character.Value.Item2, Color.White))
                {
                    g.DrawImage(characterBitmap, new Point(character.Key.X, y));
                }
            }
        }
        return deskewedBitmap;
    }
