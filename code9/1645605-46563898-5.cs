    public static class AutomationCommands
    {
        public static RoutedCommand OpenList = new RoutedCommand("OpenList", typeof(AutomationCommands), new InputGestureCollection()
        {
            new KeyGesture(Key.B, ModifierKeys.Control)
        });
        public static RoutedCommand ToggleHot = new RoutedCommand("ToggleHot", typeof(AutomationCommands), new InputGestureCollection()
        {
            new KeyGesture(Key.T, ModifierKeys.Control)
        });
        public static RoutedCommand ToggleMilk = new RoutedCommand("ToggleMilk", typeof(AutomationCommands), new InputGestureCollection()
        {
            new KeyGesture(Key.M, ModifierKeys.Control)
        });
        public static RoutedCommand ToggleLemon = new RoutedCommand("ToggleLemon", typeof(AutomationCommands), new InputGestureCollection()
        {
            new KeyGesture(Key.L, ModifierKeys.Control)
        });
        public static RoutedCommand ToggleSyrup = new RoutedCommand("ToggleSyrup", typeof(AutomationCommands), new InputGestureCollection()
        {
            new KeyGesture(Key.S, ModifierKeys.Control)
        });
    }
