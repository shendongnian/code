    public class RelayCommand : ICommand
    {
        private readonly RelayCommandBindings relayCommandBindings;
        public event EventHandler CanExecuteChanged;
        internal RelayCommand(RelayCommandBindings relayCommandBindings)
        {
            this.relayCommandBindings = relayCommandBindings;
            relayCommandBindings.BindingModel.PropertyChanged += (s, e) =>
            {
                if (relayCommandBindings.BindingProperties.Any(p => p == e.PropertyName))
                    CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            };
        }
        public bool CanExecute(object parameter) => (relayCommandBindings.CanExecuteChecks?.All(p => p.Invoke(parameter))).GetValueOrDefault();
        public void Execute(object parameter) => relayCommandBindings?.Execute?.Invoke(parameter);
    }
