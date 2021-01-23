    protected Point Location
    {
        get
        {
            return Location;   // <--- this is a circular reference..
                               //      meaning, it will recall this getter again.
        }
        set
        {
            PaddleBox.Location = new Point(value.X, value.Y);
        }
    }
