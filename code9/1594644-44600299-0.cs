    private Matrix transform = new Matrix();
    private float m_dZoomscale = 1.0f;
    public const float s_dScrollValue = 0.1f;
    public Form1()
    {
        InitializeComponent();
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.Transform = transform;
        Pen mypen = new Pen(Color.Red, 5);
        Rectangle rect = new Rectangle(10, 10, 30, 30);
        e.Graphics.DrawRectangle(mypen, rect);
    }
    protected override void OnMouseWheel(MouseEventArgs mea)
    {
        pictureBox1.Focus();
        if (pictureBox1.Focused == true && mea.Delta != 0)
        {
            // Map the Form-centric mouse location to the PictureBox client coordinate system
            Point pictureBoxPoint = pictureBox1.PointToClient(this.PointToScreen(mea.Location));
            ZoomScroll(pictureBoxPoint, mea.Delta > 0);
        }
    }
    private void ZoomScroll(Point location, bool zoomIn)
    {
        // Figure out what the new scale will be. Ensure the scale factor remains between
        // 1% and 1000%
        float newScale = Math.Min(Math.Max(m_dZoomscale + (zoomIn ? s_dScrollValue : -s_dScrollValue), 0.1f), 10);
        if (newScale != m_dZoomscale)
        {
            float adjust = newScale / m_dZoomscale;
            m_dZoomscale = newScale;
            // Translate mouse point to origin
            transform.Translate(-location.X, -location.Y, MatrixOrder.Append);
            // Scale view
            transform.Scale(adjust, adjust, MatrixOrder.Append);
            // Translate origin back to original mouse point.
            transform.Translate(location.X, location.Y, MatrixOrder.Append);
            pictureBox1.Invalidate();
        }
    }
