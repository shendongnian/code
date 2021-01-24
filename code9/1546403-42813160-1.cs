    [ImplementPropertyChanged]
    public partial class Window1 : Window
    {
        public ObservableCollection<MyTabItem> MyItems { get; set; }
        public Window1()
        {
            InitializeComponent();
            this.MyItems = new ObservableCollection<MyTabItem>();
            this.MyItems.Add(new MyTabItem { Name = "+" });
            this.DataContext = this;
        }
        #region COMMAND AddNew
        private ICommand _AddNew;
        public ICommand AddNew
        {
            get { return _AddNew ?? (_AddNew = new DelegateCommand(a => AddNewCommand(a))); }
        }
        private void AddNewCommand(object item)
        {
            var senderItem = (MyTabItem)item;
            if (senderItem.Name == "+")
            {
                this.MyItems.Remove(senderItem);
                this.MyItems.Add(new MyTabItem { Name = "Item " + (this.MyItems.Count) });
                this.MyItems.Add(senderItem);
                
            }
        }
        #endregion
    }
    [ImplementPropertyChanged]
    public class MyTabItem
    {
        public string Name { get; set; }
        public string SomePropertyToDisplay { get; set; }
        public MyTabItem()
        {
            SomePropertyToDisplay = DateTime.Now.Ticks.ToString();
        }
    }
