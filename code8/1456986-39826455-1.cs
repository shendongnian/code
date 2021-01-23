    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Random rand = new Random();
            List<Item> list = new List<Item>();
            for (int i = 1; i < 30; i++)
            {
                int count = rand.Next(100);
                String str = new string('T',count);
                var item = new Item
                {
                    Text = str
                };
                list.Add(item);
            }
            gridView.ItemsSource = list;
            base.OnNavigatedTo(e);
        }
    }
    public class Item
    {
        public String Text { get; set; }
    }
