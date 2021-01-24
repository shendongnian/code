    Point LastPos;
    private void Canvas_MouseMove(object sender, MouseEventArgs e)
    {
        Point curr_pos = e.GetPosition(this);
        Canvas grid = sender as Canvas;
        if ((e.LeftButton == MouseButtonState.Pressed))
        {
            double top = grid.GetTop();
            var diffY = curr_pos.Y - LastPos.Y;
            //If new position of canvas will be smaller then title bar size, do not transform.
            if((top + diffY) < 26)
                return;
            Matrix m = grid.RenderTransform.Value;
            m.Translate(curr_pos.X - LastPos.X, curr_pos.Y - LastPos.Y);
            grid.RenderTransform = new MatrixTransform(m);
        }
        LastPos = curr_pos;
    }
