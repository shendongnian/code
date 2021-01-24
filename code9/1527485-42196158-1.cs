    public MainPage()
    {
        this.InitializeComponent();
        var vsg = new VisualStateGroup();
        var vs = new VisualState();
        Style appButtonStyle = (Style)this.Resources["usernameStyle"];
        vs.StateTriggers.Add(new AdaptiveTrigger
        {
            MinWindowWidth = 1080
        });
    
        vs.Setters.Add(new Setter
        {
            Target = new TargetPropertyPath
            {
                Path = new PropertyPath("(TextBlock.Style)"),
                Target = txtUser
            },
            Value = appButtonStyle
        });
    
        vsg.States.Add(vs);
    
        VisualStateManager.GetVisualStateGroups(MyGrid).Add(vsg);
    }
