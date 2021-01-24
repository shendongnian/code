    public static readonly DependencyProperty MouseCapturedProperty = DependencyProperty.RegisterAttached("MouseCaptured",
            typeof(bool), typeof(QuantitiesBoxBehaviours),
            new UIPropertyMetadata(false, MouseCapturedPropertyChangedCallback));        
    public static bool GetMouseCaptured(UIElement element)
    {
        return (bool)element.GetValue(MouseCapturedProperty);
    }
    public static void SetMouseCaptured(UIElement element, bool command)
    {
        element.SetValue(MouseCapturedProperty, command);
    }
    private static void MouseCapturedPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var qBox = d as ComboBox;
        bool value = GetMouseCaptured(qBox);
        if (qBox != null && value)
        {
            qBox.IsMouseCaptureWithinChanged += QBox_IsMouseCaptureWithinChanged;
            qBox.DropDownOpened += QBox_DropDownOpened;
        }
    }
    private static void QBox_DropDownOpened(object sender, EventArgs e)
    {
        var qBox = sender as ComboBox;
        var template = qBox.Template;
        var txtBox = template.FindName("PART_EditableTextBox", qBox) as TextBox;
        var txtBlock = template.FindName("ContentSite", qBox) as TextBlock;
        txtBlock.Visibility = Visibility.Collapsed;
        txtBox.Visibility = Visibility.Visible;
    }
    private static void QBox_IsMouseCaptureWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        var qBox = sender as ComboBox;
        var template = qBox.Template;
        var txtBox = template.FindName("PART_EditableTextBox", qBox) as TextBox;
        var txtBlock = template.FindName("ContentSite", qBox) as TextBlock;
           
        if (qBox.IsDropDownOpen == false)
        {
            Keyboard.ClearFocus();
            txtBox.Visibility = Visibility.Collapsed;
            txtBlock.Visibility = Visibility.Visible;                
            qBox.ItemsSource = _presentationQuantities;
            flag = true;
        }
    }
