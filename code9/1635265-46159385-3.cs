    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ObservableCollection<Group> groupedItems = new ObservableCollection<Group>();
            Group group = new Group("First Group");
            groupedItems.Add(group);
            Item item = new Item("First Item", "First Item Description");
            group.Add(item);
            this.BindingContext = groupedItems;
        }
    }
    public class Item
    {
        public String Title { get; private set; }
        public String Description { get; private set; }
        public Item(String title, String description)
        {
            Title = title;
            Description = description;
        }
    }
    public class Group : ObservableCollection<Item>
    {
        public String Name { get; private set; }
        public Group(String Name)
        {
            this.Name = Name;
        }
    }
