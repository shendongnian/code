    foreach (RControl r in _instruments.Values)
    {
        PointF[] points = r.BackgroundRotatedRect.GetVertices();
        Bgra rectangleStroke = new Bgra(
            ((SolidColorBrush)r.RectangleStroke).Color.B,
            ((SolidColorBrush)r.RectangleStroke).Color.G,
            ((SolidColorBrush)r.RectangleStroke).Color.R,
            ((SolidColorBrush)r.RectangleStroke).Color.A);
    
        _recorderFrame.FrameImage.DrawPolyline(
                                    Array.ConvertAll(points, new Converter<PointF, System.Drawing.Point>(PointFConverter.PointFToPoint)),
                                    true,
                                    rectangleStroke,
                                    2,
                                    Emgu.CV.CvEnum.LineType.FourConnected);
    }
