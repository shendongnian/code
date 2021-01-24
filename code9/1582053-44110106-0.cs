    public System.Windows.UIElement Create()
    {
        MyControl control = new MyControl();
        var template = Application.Current.Resources["MyControlTemplate"] as ControlTemplate;
        control.Template = template;
        control.ApplyTemplate();
        var border = (Border)VisualTreeHelper.GetChild(control, 0);
        var panel = (StackPanel)VisualTreeHelper.GetChild(border, 0);
        foreach (var textBlock in panel.Children.OfType<TextBlock>())
        {
            switch (textBlock.Name)
            {
                case "controlType":
                    textBlock.Text = "MyText";
                    textBlock.InvalidateVisual();
                    break;
            }
        }
        return control;
    }
