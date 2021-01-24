     public sealed partial class MainPage : Page
     {
            public  IEnumerable<NavigationViewItemBase> Items { get; set; }
            private readonly NavigationViewItem Item1 = new NavigationViewItem() { Icon = new FontIcon() { Glyph = "\uEC06" }, Content = "Item1" };
            private readonly NavigationViewItem Item2 = new NavigationViewItem() { Icon = new FontIcon() { Glyph = "\uE13C" }, Content = "Item2" };
            private readonly NavigationViewItemHeader Header1 = new NavigationViewItemHeader() { Content = "Header1" };
            private readonly NavigationViewItem Item3 = new NavigationViewItem() { Icon = new FontIcon() { Glyph = "\uEC06" }, Content = "Item3" };
            private readonly NavigationViewItem Item4 = new NavigationViewItem() { Icon = new FontIcon() { Glyph = "\uE13C" }, Content = "Item4" };
            private readonly NavigationViewItemHeader Header2 = new NavigationViewItemHeader() { Content = "Header2" };
            public MainPage()
            {
                Items = GetItems();
                this.InitializeComponent();            
            }
            private IEnumerable<NavigationViewItemBase> GetItems()
            {
                yield return Header1;
                yield return Item1;
                yield return Item2;
                yield return Header2;
                yield return Item3;
                yield return Item4;
            }
      }
