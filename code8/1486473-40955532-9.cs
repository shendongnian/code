    namespace AmsterdamTheMapV3 {
        public partial class CategoriePage : ContentPage {
    
            public CategoriePage(int page) {
                InitializeComponent();
                this.Appearing += (s,e) => {
                    if(NotInDesignMode) {
                        var categories = App.Database.GetCategoryByMenuID(page);
                        this.listView.ItemsSource = categories;
                    }
                };
            }
            bool NotInDesignMode {
                get { return Application.Current != null; }
            }
        }
    }
