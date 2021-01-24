    //making is a bindab
    public static readonly DependencyProperty TapCommandProperty =
        DependencyProperty.Register("TapCommand", typeof(ICommand), typeof(CircleView) 
                /* possible more options here, see metadata overrides in msdn article*/);
    
    public ICommand TapCommand
    {
        get { return (ICommand)GetValue(TapCommandProperty); }
        set { SetValue(TapCommandProperty, value); }
    }
