    private void Button_Click(object sender, RoutedEventArgs e)
    {
        InkDrawingAttributes attr = new InkDrawingAttributes();
        attr.Color = Colors.Red;
        attr.IgnorePressure = true;
        attr.PenTip = PenTipShape.Circle;
        attr.Size = new Size(4, 10);
        attr.PenTipTransform = Matrix3x2.CreateRotation((float)(70 * Math.PI / 180));
        IReadOnlyList<InkStroke> InkStrokeList = MyInk.InkPresenter.StrokeContainer.GetStrokes();
        foreach (InkStroke temp in InkStrokeList)
        {
            temp.DrawingAttributes = attr; 
        }          
    }
