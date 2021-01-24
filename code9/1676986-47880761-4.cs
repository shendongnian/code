    public class MainViewModel
    {
        public List<ComboboxViewModel> Items { get; set; }
    
        public MainViewModel()
        {
            Items = new List<ComboboxViewModel>() { new ComboboxViewModel()};
        }
    }
