    // Search for good pixels and take their average color.
    // The coordinates of the bad pixel are (X, Y).
    int totR = 0, totG = 0, totB = 0, n = 0;
    for (int i = X - 1; i <= X + 1; i++) {
        for (int j = Y - 1; j <= Y + 1; j++) {
            Color p = myBitmap.GetPixel(i, j);
            if (p.R < 150 || p.G < 150 || p.B < 150) {
                // The pixel at [i, j] is a good one.
                totR += p.R; totG += p.G; totB += p.B;
                n++;
            }
        }
    }
    if (n > 0) {
        // We found at least one good pixel.
        myBitmap.SetPixel(X, Y, Color.FromArgb(totR / n, totG / n, totB / n));
    }
