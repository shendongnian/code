    public class myGraphics
    {
        // public Graphics g is no longer necessary
        public void initialize(int W, int H ) { //sets some values}
        public void draw() { // code to draw on myGraphics.bmp }
            
        public void markpoints(Graphics graph) 
        {
            if (draw_points) { 
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                graph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graph.PixelOffsetMode = PixelOffsetMode.HighQuality;
                
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
    myGraphics mg = new myGraphics()
    Picturebox.Image = mg.bmp;
    PictureBox.Invalidate(); // forces update of the control using paint event
    
    private void PictureBox_Paint(object sender, PaintEventArgs e) 
    {
        mg.markpoints(e.Graphics);
    }
            
