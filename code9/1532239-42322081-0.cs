    public static class RoutedCommands
    {
        public static readonly RoutedCommand SendChangesCommand = new RoutedCommand();
        public static void CanExecuteSendChangesCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        public static void ExecutedSendChangesCommand(object sender, ExecutedRoutedEventArgs e)
        {
           // Use  e.Parameter;
        }
    }
