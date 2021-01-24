    public MainPage()
    {
        this.InitializeComponent();
        //Register PropertyChangedCallback
        MyTextBlock.RegisterPropertyChangedCallback(TextBlock.TextProperty, OnTextChanged);
    }
    private void OnTextChanged(DependencyObject sender, DependencyProperty dp)
    {
        if((TextBlock)sender.Text = "On")
            PrevStoryBoardIn.Begin();
        else if((TextBlock)sender.Text = "Off")
            PrevStoryBoardOut.Begin();
    }
