    private void chart1_MouseDown(object sender, MouseEventArgs e)
    {
        if (cbx_drawAnnotation.Checked)
        {
            Axis ax = chart1.ChartAreas[0].AxisX;
            Axis ay = chart1.ChartAreas[0].AxisY;
            laNew = new LineAnnotation();
            chart1.Annotations.Add(laNew);
            laNew.IsSizeAlwaysRelative = false;
            laNew.AxisX = ax;
            laNew.AxisY = ay;
            laNew.AnchorX = ax.PixelPositionToValue(e.X);
            laNew.AnchorY = ay.PixelPositionToValue(e.Y);
            laNew.LineColor = rb_green.Checked ? Color.Green : Color.Red;
            laNew.AllowMoving = true;
        }
    }
    private void chart1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button.HasFlag(MouseButtons.Left) && cbx_drawAnnotation.Checked)
        {
            Axis ax = chart1.ChartAreas[0].AxisX;
            Axis ay = chart1.ChartAreas[0].AxisY;
            laNew.Width = ax.PixelPositionToValue(e.X) - laNew.AnchorX;   // values
            laNew.Height = ay.PixelPositionToValue(e.Y) - laNew.AnchorY;  
        }
    }
