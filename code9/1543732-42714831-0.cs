    static UiEventHandler()
    {
        EventManager.RegisterClassHandler(
            typeof(UIElement), UIElement.PreviewMouseDownEvent, 
            new RoutedEventHandler(PreviewMouseDown));
        EventManager.RegisterClassHandler(
            typeof(UIElement), UIElement.MouseDownEvent, 
            new RoutedEventHandler(MouseDown));
    }
    private static void MouseDown(object sender, RoutedEventArgs e)
    {
        Debug.WriteLine("MouseDown on " + sender.GetType());
    }
    private static void PreviewMouseDown(object sender, RoutedEventArgs e)
    {
        Debug.WriteLine("PreviewMouseDown on " + sender.GetType());
    }
