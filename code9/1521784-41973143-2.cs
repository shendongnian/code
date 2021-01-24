    public enum PageType { First, Second }
    public sealed partial class MultiPage : Page
    {
        public MultiPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            switch ((PageType)e.Parameter)
            {
                case PageType.First:
                    this.Content = new Button { Content = "First page" };
                    break;
                case PageType.Second:
                    this.Content = new Button { Content = "Second page" };
                    break;
                default:
                    break;
            }
        }
    }
