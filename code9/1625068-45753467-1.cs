    public class ViewModel
    {
        public ObservableCollection<Option> Options { get; }
            = new ObservableCollection<Option>();
    }
    public class Option
    {
        public string Name { get; set; }
        public ICommand Command { get; set; }
    }
