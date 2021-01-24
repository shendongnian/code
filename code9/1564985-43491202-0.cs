        private int _currentValue = false;
        public bool CurrentValue
        {
            get { return _currentValue; }
            set 
              { 
                  SetProperty(ref _currentValue, value); 
                  CommandOne.RaiseCanExecuteChanged();
                  CommandTwo.RaiseCanExecuteChanged();   
              }
        }
    CommandBindings.Add(new CommandBinding(CommandOne, CommandOne_Executed, CommandOne_CanExecute));
    CommandBindings.Add(new CommandBinding(CommandTwo, CommandTwo_Executed, CommandTwo_CanExecute));
    
    public static readonly RoutedUICommand CommandOne = new RoutedUICommand();
    public static readonly RoutedUICommand CommandTwo = new RoutedUICommand();
    
    private void CommandOne_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        if (e != null)
            e.CanExecute = (CurrentValue > 1);
    }
    
    private void CommandTwo_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        if (e != null)
            e.CanExecute = (CurrentValue > 100);
    }
    private async Task DoSomeWork(int value)
    {
        await Task.Run(() =>
        {
            // Do some work on value
            CurrentValue = value
        }
    }
