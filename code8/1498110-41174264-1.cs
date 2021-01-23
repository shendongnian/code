    public class MenuItem
    {
        public string Text { get; set; }
        public List<MenuItem> SubItems { get; set; }
    }
    public sealed partial class MainPage : Page
    {
        public List<MenuItem> MenuItems { get; }
        public MainPage()
        {
            InitializeComponent();
            MenuItems = Enumerable.Range(1, 3).Select(i => new MenuItem()
            {
                Text = $"Menu item {i}",
                SubItems = Enumerable.Range(1, 3).Select(j => new MenuItem()
                {
                    Text = $"Sub item {i}.{j}",
                }).ToList(),
            }).ToList();
        }
        private void onItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var item in menu.Items)
            {
                var container = (ListViewItem)menu.ContainerFromItem(item);
                if (container != null)
                {
                    var subMenu = (container.ContentTemplateRoot as FrameworkElement)?.FindName("subMenu") as FrameworkElement;
                    if (subMenu != null)
                    {
                        subMenu.Visibility = e.ClickedItem == item ? Visibility.Visible : Visibility.Collapsed;
                    }
                }
            }
        }
    }
