    public CustomShape()
    {
            rectangle.SetBinding(Rectangle.FillProperty,
                new Binding("Fill") { Source = this });
    }
