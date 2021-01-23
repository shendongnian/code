    namespace AmsterdamTheMapV3 {
        public partial class CategoriePage : ContentPage {
    
            public CategoriePage(string txt) {
                InitializeComponent();
                this.Appearing += (s,e) => {
                    if(NotInDesignMode) {
                        int page = 0;
                        if(int.TryParse(txt, out page)){
                            var categories = App.Database.GetCategoryByMenuID(page);
                            this.listView.ItemsSource = categories;
                        }
                    }
                };
            }
            bool NotInDesignMode {
                get { return Application.Current != null; }
            }
        }
    }
