    private void btnErase_Click(object sender, EventArgs e)
    {
        int numberOfPointsToErase = 20;
        if (_drawingPath.PointCount > numberOfPointsToErase)
        {
            _drawingPath = new GraphicsPath(
                _drawingPath.PathPoints.Skip(numberOfPointsToErase).ToArray(),
                _drawingPath.PathTypes.Skip(numberOfPointsToErase).ToArray()
            );
        }
        else
        {
            _drawingPath.Reset();
        }
        this.Invalidate();
    }
