    private void Brick_MouseMove(object sender, MouseEventArgs e)
    {
        if (isDragging)
        {
            var relativePoint = this.PointToClient(Cursor.Position);
            Brick1.Left = relativePoint.X;
            Brick1.Top = relativePoint.Y;
        }
    }
