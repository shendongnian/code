    class IMSPictureBox : PictureBox
    {
        private Color colorSetting = Color.Black;
        private float width = 1.0f;
        private Tuple<Point, Point> _verticalLine;
        private Tuple<Point, Point> _horizontalLine;
        public IMSPictureBox()
        {
            this.Paint += IMSPictureBox_Paint;
        }
        private void IMSPictureBox_Paint(object sender, PaintEventArgs e)
        {
            //Draw if image has loaded
            if (this.Image != null)
            {
                //Draw vertical line
                if (_verticalLine == null)
                {
                    _verticalLine = new Tuple<Point, Point>(new Point(100, 0), new Point(100, this.Size.Height);
                }
                e.Graphics.DrawLine(
                  new Pen(this.colorSetting, this.width),
                  _verticalLine.Item1,
                  _verticalLine.Item2);
                //Draw horizontal line
                if (_horizontalLine == null)
                {
                    _horizontalLine = new Tuple<Point, Point>(new Point(0, 100), new Point(this.Size.Width, 100);
                }
                e.Graphics.DrawLine(
                  new Pen(this.colorSetting, this.width),
                  _horizontalLine.Item1,
                  _horizontalLine.Item2);
            }
        }
    }
