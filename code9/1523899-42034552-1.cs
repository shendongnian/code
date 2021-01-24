    public PanelBackgroundType PanelBackgroundType
    {
        get { return (PanelBackgroundType)GetValue(PanelBackgroundTypeProperty); }
        set { SetValue(PanelBackgroundTypeProperty, value); }
    }
    
    // Using a DependencyProperty as the backing store for PanelBackgroundType.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty PanelBackgroundTypeProperty =
        DependencyProperty.Register("PanelBackgroundType", typeof(PanelBackgroundType), typeof(MyControl), 
        new PropertyMetadata(PanelBackgroundType.Offwhite, (s, e) =>
        {
            if ((PanelBackgroundType)e.NewValue != (PanelBackgroundType)e.OldValue)
            {
                // value really changed, invoke your changed logic here
                var control = (MyControl)s;
    
                switch ((PanelBackgroundType)(e.NewValue))
                {
                    case PanelBackgroundType.Orange:
                        control.MyStackPanel.Background = new SolidColorBrush(Colors.Orange);
                        break;
                    case PanelBackgroundType.Pink:
                        control.MyStackPanel.Background = new SolidColorBrush(Colors.Pink);
                        break;
                    case PanelBackgroundType.Offwhite:
                    default:
                        control.MyStackPanel.Background = new SolidColorBrush(Colors.Wheat);
                        break;
                }
            }
            else
            {
                // else this was invoked because of boxing, do nothing
            }
        }));
