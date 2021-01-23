    var tbContent = new TextBlock()
    {
        Text = "Hello World",
        FontSize=15
    };
    var button = new Button
    {
        Content = tbContent,
    };
    var h= button.DesiredSize.Height;
    button.Measure(new Size(200, double.PositiveInfinity));
    var height = button.DesiredSize.Height;
    var width = button.DesiredSize.Width;
