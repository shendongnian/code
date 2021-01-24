    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaiseProperty(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        private bool isSwitched = false;
        public bool IsSwitched
        {
            get { return isSwitched; }
            set { isSwitched = value; RaiseProperty(nameof(IsSwitched)); }
        }
        public MainPage() { this.InitializeComponent(); }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            ListOfItems.Items.Add(new ItemClass { Type = isSwitched ? ItemType.Greed : ItemType.Red, Text = "NEW ITEM" });
        }
    }
    public enum ItemType { Red, Greed };
    public class ItemClass
    {
        public ItemType Type { get; set; }
        public string Text { get; set; }
    }
    public class MySelector : DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            switch ((item as ItemClass).Type)
            {
                case ItemType.Greed:
                    return GreenTemplate;
                case ItemType.Red:
                default:
                    return RedTemplate;
            }
        }
        public DataTemplate GreenTemplate { get; set; }
        public DataTemplate RedTemplate { get; set; }
    }
