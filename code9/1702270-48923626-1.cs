    public CustomShape()
    {
        rectangle.SetBinding(Rectangle.FillProperty, new Binding
        {
            Path = new PropertyPath(FillProperty),
            Source = this
        });
    }
