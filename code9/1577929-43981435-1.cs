    public ICommand TheaterManageRoomClickOnCanvas
    {
        get { return new RelayCommand<EventArgs>(TheaterManageRoomClickOnCanvasFunc); }
    }
    private void TheaterManageRoomClickOnCanvasFunc(EventArgs args) {
        MouseEventArgs e = (MouseEventArgs)args;
        var position = e.GetPosition(e.Device.Target);
        TheaterManageRoomPoints.Add(new RectItem(position.X, position.Y));
    }
