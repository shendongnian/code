    namespace AmsterdamTheMapV3
    {
        public partial class CategoriePage : ContentPage
        {
    
            public CategoriePage(String txt)
            {
                InitializeComponent();
                this.Appearing += (s,e) => {
                    int page = Int32.Parse(txt);
                    var categories = App.Database.GetCategoryByMenuID(page);
                    this.listView.ItemsSource = categories;
                };
            }
        }
    }
