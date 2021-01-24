    public static readonly DependencyProperty BodyProperty = 
    DependencyProperty.Register("Body", 
                                typeof(ViewModels.ItemContent), 
                                typeof(TabItemControl), 
                                new PropertyMetadata(null));
    public ViewModels.ItemContent Body
    {
        get
        {
            return (ViewModels.ItemContent)GetValue(BodyProperty);
        }
        set
        {
            SetValue(BodyProperty, value);
        }
    }
    public string BodyText {
        get
        {
            return Body?.Name;
        }
        set
        {
            if (Body != null)
            {
                Body.Name = value;
            }
        }
    }
