     public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            List<Item> available_Nums = new List<Item>();
            available_Nums.Add(new Item { Number = 1, Text = "One" });
            available_Nums.Add(new Item { Number = 2, Text = "Two" });
            available_Nums.Add(new Item { Number = 3, Text = "Three" });
            available_Nums.Add(new Item { Number = 4, Text = "Four" });
            available_Nums.Add(new Item { Number = 5, Text = "Five" });
            combobox1.ItemsSource = available_Nums;   
        }
     
    }
    public class Item
    {
        public int Number { get; set; }
        public string Text { get; set; }
    }
