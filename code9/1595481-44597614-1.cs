    protected override void OnMouseDown(MouseEventArgs e) {
      using (Graphics g = this.CreateGraphics()) {
        g.TranslateTransform(this.ClientSize.Width / 2, this.ClientSize.Height / 2);
        Point[] points = new Point[] { e.Location };
        g.TransformPoints(CoordinateSpace.World, CoordinateSpace.Device, points);
        MessageBox.Show(points[0].ToString());
      }      
    }
