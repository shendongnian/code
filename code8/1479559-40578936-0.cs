    public class NavigationService : INavigationService
    {
        private readonly Container container;
        public NavigationService(Container container)
        {
            this.container = container;
        }
        public void ShowView<TView>() where TView : Window 
        {
            var view = this.CreateWindow<TView>();
            view.Show();
        }
        public bool? ShowDialog<TView>() where TView : Window
        {
            var view = this.CreateWindow<TView>();
            return view.ShowDialog();
        }
        private Window CreateWindow<TView>() where TView : Window
        {
            return this.container.GetInstance<TView>();
        }
    }
