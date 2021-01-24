    public class ViewModel
    {
        public ViewModel()
        {
            this.StartInspectionCommand = new DelegateCommand(this.StartInspection, () => this.Parameters.All(p => string.IsNullOrEmpty(p["Value"])))
            this.Parameters.CollectionChanged += Parameters_CollectionChanged;
        }
        public ObservableCollection<Parameter> Parameters { get; } = new ObservableCollection<Parameter>();
        private void Parameters_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (object parameter in e.NewItems)
                {
                    (parameter as INotifyPropertyChanged).PropertyChanged
                        += new PropertyChangedEventHandler(item_PropertyChanged);
                }
            }
            if (e.OldItems != null)
            {
                foreach (object parameter in e.OldItems)
                {
                    (parameter as INotifyPropertyChanged).PropertyChanged
                        -= new PropertyChangedEventHandler(item_PropertyChanged);
                }
            }
        }
        private void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            StartInspectionCommand.RaiseCanExecuteChanged();
        }
        //...
    }
