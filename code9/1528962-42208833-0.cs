    public class myGraphics
    {
        public Graphics g;
        public void initialize(int W, int H ) {
            //sets some values 
            g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        }
        public void draw() { // code to draw on myGraphics.bmp }
            
        public void markpoints() 
        {
            if (draw_points) { 
                foreach (objecto ob in solidos) {
                    for (int p = 0; p < ob.viewpoints.Count; p++)
                    {
                        // determine position of text (x, y)
                        SolidBrush drawBrush = new SolidBrush(Color.Black);
                        g.DrawString(p.ToString(), new Font("Arial", 10), drawBrush, x, y);
                    }
                }
            }
        }
    }
    // Connect to picture box
    myGraphics graph = new myGraphics()
    myGraphics.g = Picturebox.CreateGraphics();
    
    // When updating:
    Picturebox.Image = graph.bmp;
    graph.markpoints();
