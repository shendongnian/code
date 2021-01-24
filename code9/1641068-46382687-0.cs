    private bool _isMoving;
    private Point? _buttonPosition;
    private double deltaX;
    private double deltaY;
    private TranslateTransform _currentTT;
    
    private void Samplebutton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        if(_buttonPosition == null)
            _buttonPosition = Samplebutton.TransformToAncestor(MyGrid).Transform(new Point(0, 0));
        var mousePosition = Mouse.GetPosition(MyGrid);
        deltaX = mousePosition.X - _buttonPosition.Value.X;
        deltaY = mousePosition.Y - _buttonPosition.Value.Y;
        _isMoving = true;
    }
    
    private void Samplebutton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
    {
        _currentTT = Samplebutton.RenderTransform as TranslateTransform;
        _isMoving = false;
    }
    
    private void Samplebutton_PreviewMouseMove(object sender, MouseEventArgs e)
    {
        if (!_isMoving) return;
    
        var mousePoint = Mouse.GetPosition(MyGrid);
    
        var offsetX = (_currentTT == null ?_buttonPosition.Value.X : _buttonPosition.Value.X - _currentTT.X) + deltaX - mousePoint.X;
        var offsetY = (_currentTT == null ? _buttonPosition.Value.Y : _buttonPosition.Value.Y - _currentTT.Y) + deltaY - mousePoint.Y;
        
        this.Samplebutton.RenderTransform = new TranslateTransform(-offsetX, -offsetY);
    }
