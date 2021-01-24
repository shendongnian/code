    public partial class MainWindow : Window
    {
      public MainWindow()
      {
        InitializeComponent();
        DataContext = this;
        Items = new ObservableCollection<Item>();
        Items.Add(new Item("bla"));
        Items.Add(new Item("blub"));
        Items.Add(new Item("blubber"));
     }
      public ObservableCollection<Item> Items { get; set; }
      private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
      {
        Items.Add(new Item("test"));
      }
    }
    public class Item
    {
      public Item(string name)
      {
        Name = name;
      }
      public string Name { get; set; }
    }
