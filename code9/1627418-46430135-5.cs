    public class CustomTabbedPage : TabbedPage
    {
        public CustomTabbedPage()
        {
            this.CurrentPageChanged += OnTabbedPageTabChanged;
        }
        
        void OnTabbedPageTabChanged(object sender, EventArgs e)
        {
            PageService.CurrentPage = ((App)App.Current).FindCurrentPage();
        }
    }
