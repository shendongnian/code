    private void ContentControl_Loaded(object sender, RoutedEventArgs e)
    {
        var control = (ContentControl)sender;
        control.SetBinding(ContentControl.ContentProperty, new Binding
        {
            Path = new PropertyPath(AttachedProperties.VisualIconProperty),
            RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor)
            {
                AncestorType = typeof(MenuItem),
            },
        });
    }
