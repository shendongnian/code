    public class ViewModel
    {
        public ObservableCollection<Model> MyList { get; set; }
        public ViewModel()
        {
            MyList = new ObservableCollection<Model>();
            MyList.Add(new Model() { Name = "John", IsChecked = true });
            MyList.Add(new Model() { Name = "Bety", IsChecked = false });
            MyList.Add(new Model() { Name = "Samuel", IsChecked = true });
        }
    }
