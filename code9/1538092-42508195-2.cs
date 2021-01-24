    public class ViewModel
    {
        private ViewModel(string title)
        {
            Title = title;
        }
        public string Title { get; private set; }
        public static ViewModel CreateAndInitialize(string title)
        {
            return new ViewModel(title);
        }
    }
