    public class ChapterPageViewModel
    {
        public ChapterPageViewModel()
        {
            this.PageResizedCommand = new DelegateCommand(OnPageResized);
        }
        public DelegateCommand PageResizedCommand { get; }
        private void OnPageResized()
        {  }
    }
