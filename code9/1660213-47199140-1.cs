    public class ItemViewModel : BaseViewModel
    {
        public string Title { get; set; }
        private bool isVisible;
        public bool IsVisible
        {
            get { return isVisible; }
            set { SetField(ref isVisible, value); }
        }
    }
