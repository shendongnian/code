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
    
        public static async Task<MenuPage> CreateMenuPageAsync(string masa) {
            var page = new MenuPage(masa);
            await page.LoadRestoransAsync();
            return pagel
        }
    }
