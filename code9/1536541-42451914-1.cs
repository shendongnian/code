    internal class RelayCommandBindings
    {
        public Action<object> Execute { get; set; }
        public IEnumerable<Predicate<object>> CanExecuteChecks { get; set; }
        public INotifyPropertyChanged BindingModel { get; set; }
        public IEnumerable<string> BindingProperties { get; set; }
    }
