    public class MenuPage : ContentPage {
        ListView listView;
        List<Restoran> restorans = new List<Restoran>();
        private async Task LoadRestoransAsync() {
            restorans = (await DataSource.GetRestoransAsync()).ToList();
            listView = new ListView(ListViewCachingStrategy.RecycleElement) {
                ItemsSource = restorans,
                ItemTemplate = new DataTemplate(() => {
                    var nativeCell = new CustomCell();
                    return nativeCell;
                })
            };
        }
    
        public MenuPage(string masa) {
            //...        
        }
    
        protected override void OnAppearing() {
            this.Appearing += Page_Appearing;
        }
        private async void Page_Appearing(object sender, EventArgs e) {
            //...call async code here
            await LoadRestoransAsync();
            //unsubscribing from the event
            this.Appearing -= Page_Appearing;
        }
    }
