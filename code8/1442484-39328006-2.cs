    public class ViewModel
    {
        public ViewModel()
        {
            Items.Add(new MyItemViewModel("Item1"));
            Items.Add(new MyItemViewModel("Item2"));
            Items.Add(new MyItemViewModel("Item3"));
        }
        public ApplicationDataLocality ApplicationDataLocalityEnum { get; } =
               ApplicationDataLocality.Local;
        public FontStyle FontStyleEnum { get; } =
                   FontStyle.Normal;
        public ObservableCollection<MyItemViewModel> Items { get; set; } = new ObservableCollection<MyItemViewModel>();
    }
