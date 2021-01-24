    private readonly Random R = new Random();
    private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        byte r;
        byte b;
        byte g;
        byte a;
        do
        {
            r = (byte)R.Next(0, 255);
            b = (byte)R.Next(0, 255);
            g = (byte)R.Next(0, 255);
            a = (byte)R.Next(128, 255);
        }
        while (r + b + g < 200);
        Color CellColor = new Color();
        CellColor.B = b;
        CellColor.G = g;
        CellColor.R = r;
        CellColor.A = a;
        var row = e.Row;
        row.Background = new SolidColorBrush(CellColor);
    }
