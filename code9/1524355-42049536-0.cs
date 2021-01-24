    var d = new System.Windows.Shapes.Ellipse();
    ImageBrush ib = new ImageBrush();
    ib.ImageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri("images/error.png", UriKind.Relative));
    d.Fill = ib;
    
    this.Content = d; // assuming the parent is a Window
