    public class CustomItem
    {
        public String Title { get; set; }
        public ObservableCollection<string> Foo { get; set; } = new ObservableCollection<string>();
        public String SelectedFoo { get; set; }
    }
