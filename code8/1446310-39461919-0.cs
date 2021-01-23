        public IEnumerable<ItemTable> SearchItem(string itemName)
        {
            return (from i in
                    _connection.Table<ItemTable>()
                    where i.ItemName.StartsWith(itemName)
                    select i).ToArray();
        }
        private string DisplayItemsInLabel(string itemName)
        {
            var searchedItems = this.SearchItem(itemName); // get items using above method that you have written already.
             
            // get name and price
            var displayableItems = searchedItems.Select(i => string.Format("Name :{0}, Price :{1}", i.Name, i.Price));
           // create a formatted string using name and the price. so that we can display it in a label.
            return string.Join(Environment.NewLine, displayableItems);
        }
        public LabelPage()
        {
            InitializeComponent();
            var layout = new StackLayout { Padding = new Thickness(5, 10) };
            this.Content = layout;
            //display contents in a label
            var label = new Label { Text = DisplayItemsInLabel("MyItem"), TextColor = Color.FromHex("#77d065"), FontSize = 20 };
            layout.Children.Add(label);
        }
