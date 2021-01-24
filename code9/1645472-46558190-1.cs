    public override void OnApplyTemplate()
    {
        var btnButton = GetTemplateChild("btnButton") as Button;
        if (btnButton != null)
            btnButton.Click += ButtonClick;
        base.OnApplyTemplate();
    }
    public event RoutedEventHandler ButtonClick;
    private void OnButtonClick(object sender, RoutedEventArgs e) { }
