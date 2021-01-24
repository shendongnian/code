    public class MyControl : Control
    {
        static MyControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyControl), new FrameworkPropertyMetadata(typeof(MyControl)));
        }
        
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command",
            typeof(ICommand),
            typeof(MyControl),
            new PropertyMetadata(null, OnCommandPropertyChanged));
        private static void OnCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MyControl control = d as MyControl;
            if (control == null) return;
            control.MouseLeftButtonDown -= OnControlLeftClick;
            control.MouseLeftButtonDown += OnControlLeftClick;
        }
        private static void OnControlLeftClick(object sender, MouseButtonEventArgs e)
        {
            MyControl control = sender as MyControl;
            if (control == null || control.Command == null) return;
            ICommand command = control.Command;
            if (command.CanExecute(null))
                command.Execute(null);
        }
    }
