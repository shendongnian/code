    public sealed class ViewModel : INotifyPropertyChanged
    {
        private int calls;
        public ViewModel()
        {
            SafeOnceCommand = new RelayCommand(DoItOnce, HasDoneIt);    
        }
        private bool HasDoneIt()
        {
            return Calls == 0;
        }
        private void DoItOnce()
        {
            if (Calls > 0) throw new InvalidOperationException();
            Calls++;
        }
        public int Calls
        {
            get { return calls; }
            set
            {
                if (value == calls) return;
                calls = value;
                OnPropertyChanged();
                SafeOnceCommand.RaiseCanExecuteChanged();
            }
        }
        public RelayCommand SafeOnceCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public sealed class RelayCommand : ICommand
    {
        private readonly Action execute;
        private readonly Func<bool> canExecute;
        private readonly List<EventHandler> invocationList = new List<EventHandler>();
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return canExecute();
        }
        public void Execute(object parameter)
        {
            execute();
        }
        /// <summary>
        /// Method to raise CanExecuteChanged event
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            foreach (var elem in invocationList)
            {
                elem(null, EventArgs.Empty);
            }
        }
        public event EventHandler CanExecuteChanged
        {
            add { invocationList.Add(value); }
            remove { invocationList.Remove(value); }
        }
    }
