    public class DummyControl : FrameworkElement
        {                   
            protected override void OnRender(DrawingContext ctx)
            {          
                Pen penTransparent = new Pen(Brushes.Transparent, 0);
                ctx.DrawGeometry(Brushes.Green, null, rectGeo);
                ctx.DrawGeometry(Brushes.Red, new Pen(Brushes.Red, 3), line1Geo);
                ctx.DrawGeometry(Brushes.Red, new Pen(Brushes.Red, 3), line2Geo);
    
                base.OnRender(ctx);
            }
            
            RectangleGeometry rectGeo;
            LineGeometry line1Geo, line2Geo;
    
            public DummyControl()
            {
                rectGeo = new RectangleGeometry(new Rect(0, 0, 1000, 1000));
                line1Geo = new LineGeometry(new Point(0, 500), new Point(1000, 500));
                line2Geo = new LineGeometry(new Point(500, 0), new Point(500, 1000));
    
                this.MouseDown += DummyControl_MouseDown;
            }
    
            void DummyControl_MouseDown(object sender, MouseButtonEventArgs e)
            {
                
            }
        }
