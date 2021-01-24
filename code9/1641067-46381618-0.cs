    private double _startX; // Or whatever number type Mouse.GetPosition(MyGrid).X returns
    private double _startY; // Or whatever number type Mouse.GetPosition(MyGrid).Y returns   
    private void Samplebutton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        _startX = Mouse.GetPosition(MyGrid).X;
        _startY = Mouse.GetPosition(MyGrid).Y;
        _isMoving = true;
    }
    private void Samplebutton_PreviewMouseMove(object sender, MouseEventArgs e)
    {
        if (!_isMoving) return;
    
        TranslateTransform transform = new TranslateTransform();
        transform.X = Mouse.GetPosition(MyGrid).X - _startX;
        transform.Y = Mouse.GetPosition(MyGrid).Y - _startY;
        this.Samplebutton.RenderTransform = transform;
    }
