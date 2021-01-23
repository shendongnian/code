        LineAnnotation laNew = null;
        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {
            if (cbx_drawAnnotation.Checked)
            {
                Axis ax = chart1.ChartAreas[0].AxisX;
                Axis ay = chart1.ChartAreas[0].AxisY;
                laNew = new LineAnnotation();
                chart1.Annotations.Add(laNew);
                double vx = ax.ValueToPosition(ax.PixelPositionToValue(e.X));
                double vy = ay.ValueToPosition(ay.PixelPositionToValue(e.Y));
                laNew.X = vx;
                laNew.Y = vy;
            }
        }
        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left) && cbx_drawAnnotation.Checked)
            {
                Axis ax = chart1.ChartAreas[0].AxisX;
                Axis ay = chart1.ChartAreas[0].AxisY;
                double vx = ax.ValueToPosition(ax.PixelPositionToValue(e.X))- laNew.X;
                double vy = ay.ValueToPosition(ay.PixelPositionToValue(e.Y)) - laNew.Y;
                laNew.Width =  Math.Min(100, vx);
                laNew.Height =  Math.Min(100, vy);
                laNew.LineColor = rb_green.Checked ? Color.Green : Color.Red;
                laNew.AllowMoving = true;  // optional
            }
        }
