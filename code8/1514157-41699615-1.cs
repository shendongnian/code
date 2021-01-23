    Pen bluePen= new Pen(Brushes.DeepSkyBlue);
    Image img = Image.FromFile("my_granny.jpg");
    List<System.Drawing.Point> points = new List<System.Drawing.Point>();
    // fill points here ...
    System.Diagnostics.Stopwatch s1 = System.Diagnostics.Stopwatch.StartNew();
    using (Graphics dr = Graphics.FromImage(img))
    {
        dr.DrawLines(bluePen, points);
    }
    s1.Stop();
    // do something with your img here
