    public class MyWidget: Gtk.DrawingArea {       
        public MyWidget(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.SetSizeRequest( width, height );
            this.ExposeEvent += (o, args)  => this.OnExposeDrawingArea();
        }
        
        /// <summary>
        /// Redraws the widget
        /// </summary>
        private void OnExposeDrawingArea()
        {
            using (var canvas = Gdk.CairoHelper.Create( this.GdkWindow ))
            {
                // Draw with the canvas
                // /* i.e. */ canvas.LineTo( 100, 100 );
                canvas.Stroke();
                // Clean
                canvas.GetTarget().Dispose();
            }
        }
    }
