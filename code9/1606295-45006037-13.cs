    public class ViewModel
    {
        private static ViewModel viewModel;
        public static ViewModel Instance
        {
            get { return viewModel ?? (viewModel = new ViewModel()); }
        }
        public bool IsAdmin { get; set; }
    }
