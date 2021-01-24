    public class MenuPage : ContentPage
    {
        ListView listView;
        List<Restoran> restorans;
        async Task<Restoran[]> LoadRestorans()
        {
            return await DataSource.GetRestoransAsync();
        }
    
        public MenuPage(string masa)
        {
            this.restorans = LoadRestorans().GetAwaiter().GetResult().ToList();
            listView = new ListView(ListViewCachingStrategy.RecycleElement)
            {
            ItemsSource = this.restorans,
                ItemTemplate = new DataTemplate(() => {
                    var nativeCell = new CustomCell();
                    return nativeCell;
                })
            };
        }
    }
