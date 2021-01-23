        protected override void OnRender (DrawingContext drawingContext)
        {
            double radius = RenderSize.Height / 2;
            var sg = new StreamGeometry ();
            using (var ctx = sg.Open ())
            {
                ctx.BeginFigure (new Point(0, 0), true, true);
                ctx.LineTo (new Point(RenderSize.Width - radius, 0), true, false);
                ctx.ArcTo (new Point (RenderSize.Width - radius, RenderSize.Height), new Size (radius, radius), 0, true, SweepDirection.Clockwise, true, false);
                ctx.LineTo (new Point(0, RenderSize.Height), true, false);
            }
            var pen = new Pen (Stroke, StrokeThickness);
            drawingContext.DrawGeometry (Fill, pen, sg);
        }
