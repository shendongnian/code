        public MainWindow()
        {
            InitializeComponent();
            CommandBindings.Add(new CommandBinding(RoutedCommands.SendChangesCommand,                       RoutedCommands.ExecutedSendChangesCommand,RoutedCommands.CanExecuteSendChangesCommand));
        }
