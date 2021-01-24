    [PropertyChanged.ImplementPropertyChanged]
    public class ViewModel
    {
        public ObservableCollection<Foo> Foos { get; set; }
        //This is the property to hold the selected item.
        public Foo SelectedFoo { get; set; }
    }
