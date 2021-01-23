    var myFont = new Font("Arial", 10);
    for (int i = 0; i < k; i += 2)
    {
        var point1 = new Point(X[i], Y[i]);
        var point2 = new Point(X[i + 1], Y[i + 1]);
        e.Graphics.DrawLine(aBrush, point1, point2);
        e.Graphics.DrawString((i + 1).ToString(), myFont, System.Drawing.Brushes.Gray, point1);
        e.Graphics.DrawString((i + 2).ToString(), myFont, System.Drawing.Brushes.Gray, point2);
    }
