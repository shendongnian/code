    public Class1()
    {
        Title = "Class1";
        Height = 150;
        Width = 300;
        Content = new ContentControl
        {
            Template = new ControlTemplate()
            {
                VisualTree = new FrameworkElementFactory(typeof(Template1))
            }
        };
    }
