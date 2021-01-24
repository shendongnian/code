    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();
        void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ItemListBox.SelectedItem is Item item) {
                // select the tab if one was already created for the item;
                // otherwise, create a new tab for it
                if (TabExists(item.Name, out TabItem tab)) {
                    ItemTabControl.SelectedItem = tab;
                }
                else {
                    var newItem = new ItemTabItem() {
                        Item = (Item)ItemListBox.SelectedItem
                    };
                    int newIndex = ItemTabControl.Items.Add(newItem);
                    ItemTabControl.SelectedIndex = newIndex;
                }
            }
        }
        bool TabExists(string name, out TabItem tab)
        {
            tab = (from object item in ItemTabControl.Items
                   let t = item as ItemTabItem
                   where t != null && t.Item.Name == name
                   select t).FirstOrDefault();
            return (tab != null);
        }
    }
