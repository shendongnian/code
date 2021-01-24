    public static class customCommands
    {
        static customCommands()
        {
            saveFile = new RoutedCommand("saveFile", typeof(MainWindow));
        }
        public static RoutedCommand saveFile { get; private set; }
    }
