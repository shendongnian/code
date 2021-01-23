    public class CommandTextBox : TextBox, ICommandSource
    {
        private bool _canExecute;
        private EventHandler _canExecuteChanged;
        protected override bool IsEnabledCore
        {
            get 
            {
                if (Command != null)
                    return base.IsEnabledCore && _canExecute;
                return base.IsEnabledCore;
            }
        }
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(CommandTextBox), new PropertyMetadata(OnCommandChanged));
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        
        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(CommandTextBox));
        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        
        public static readonly DependencyProperty CommandTargetProperty = DependencyProperty.Register("CommandTarget", typeof(IInputElement), typeof(CommandTextBox));
        public IInputElement CommandTarget
        {
            get { return (IInputElement)GetValue(CommandTargetProperty); }
            set { SetValue(CommandTargetProperty, value); }
        }
        
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            if (e.Key == Key.Enter)
            {
                if (Command != null)
                {
                    RoutedCommand command = Command as RoutedCommand;
                    if (command != null)
                        command.Execute(CommandParameter, CommandTarget);
                    else
                        Command.Execute(CommandParameter);
                }
                e.Handled = true;
            }
        }
        
        private void AddCommand(ICommand command)
        {
            var handler = new EventHandler(CanExecuteChanged);
            _canExecuteChanged = handler;
            if (command != null)
                command.CanExecuteChanged += _canExecuteChanged;
        }
        
        private void CanExecuteChanged(object sender, EventArgs e)
        {
            if (Command != null)
            {
                RoutedCommand command = Command as RoutedCommand;
                // If a RoutedCommand. 
                if (command != null)
                    _canExecute = command.CanExecute(CommandParameter, CommandTarget);
                else
                    _canExecute = Command.CanExecute(CommandParameter);
            }
            CoerceValue(UIElement.IsEnabledProperty);
        }
        
        private void HookUpCommand(ICommand oldCommand, ICommand newCommand)
        {
            // If oldCommand is not null, then we need to remove the handlers. 
            if (oldCommand != null)
                RemoveCommand(oldCommand);
            
            AddCommand(newCommand);
        }
        
        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CommandTextBox)d).HookUpCommand((ICommand)e.OldValue, (ICommand)e.NewValue);
        }
        
        private void RemoveCommand(ICommand command)
        {
            EventHandler handler = CanExecuteChanged;
            command.CanExecuteChanged -= handler;
        }
    }
