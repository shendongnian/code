    button1.Content = "new content xayxax ";
    var size = new Size(double.PositiveInfinity, double.PositiveInfinity);
    button1.Measure(size);
    button1.Arrange(new Rect(button1.DesiredSize));
    MessageBox.Show(button1.ActualWidth.ToString());
