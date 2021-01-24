    // non-related code is omitted
    public class ParentViewModel: ViewModelBase
    {
        private ObservableCollection<ChildViewModel> children;
        public string ParentString { get; }
        // don't do collection properties on view models
        // as get-set ones, unless you know exactly what are you doing;
        // usually you don't need to set them explicitly from outside
        public ObservableCollection<ChildViewModel> MyChildren
        {
            get
            {
                if (children == null)
                {
                    children = new ObservableCollection<ChildViewModel>();
                    children.CollectionChanged += ChildrenChanged;
                }
                return children;
            }
        }
        private void ChildrenChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // assuming, that only two actions ("add" and "remove") are available;
            // if you really need to nadle "reset" and "replace", add appropriate code;
            // note, that "reset" doesn't provide acceess to removed items
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    ((ChildViewModel)e.NewItems[0]).PropertyChanged += ChildPropertyChanged;
                    break;
                case NotifyCollectionChangedAction.Remove:
                    ((ChildViewModel)e.OldItems[0]).PropertyChanged -= ChildPropertyChanged;
                    break;
            }
        }
        private void ChildPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ChildViewModel.ChildString))
            {
                RaisePropertyChanged(nameof(ParentString));
            }
        }
    }
