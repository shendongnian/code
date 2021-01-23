    var style = new Style();
    style.Colors = new List<Color> {
        Color.FromArgb(10, 20, 30),
        Color.FromArgb(15, 25, 35)
    };
    style.Pens = new List<Pen> {
        new Pen(Color.Red, 5f),
        new Pen(Color.Green, 4f)
    };
    style.Save("style.xml");
    var style2 = new Style();
    style2.Load("style.xml");
