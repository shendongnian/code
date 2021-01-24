    static class RoutedCommands
    {
        public static RoutedUICommand NewMap = new RoutedUICommand(
            "New Map",
            "NewMap",
            typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.M, ModifierKeys.Control | ModifierKeys.Shift),
                new KeyGesture(Key.A, ModifierKeys.Control | ModifierKeys.Shift)
            }
            );
    }
