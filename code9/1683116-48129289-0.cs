    public class League
    {
        public string Name { get; set; }
        public Country Country { get; set; }
    }
    public class Country
    {
        public string Name { get; set; }
        public string ISO { get; set; }
    }
    public class CheckedListItem<T> 
    {
        private bool isChecked;
        private T item;
        public CheckedListItem() { }
        public CheckedListItem(T item, bool isChecked = false)
        {
            this.item = item;
            this.isChecked = isChecked;
        }
        public T Item
        {
            get { return item; }
            set
            {
                item = value;
               
            }
        }
        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
               
            }
        }
    }
     public partial class MainWindow : Window 
    {
        public ObservableCollection<CheckedListItem<League>> Competitions { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Competitions = new ObservableCollection<CheckedListItem<League>> { (new CheckedListItem<League>
            {
                IsChecked = true,
                Item = new League { Name = "foo", Country = new Country { Name = "Italy" } }
            }),
            (new CheckedListItem<League>
            {
                IsChecked = true,
                Item = new League { Name = "foo2", Country = new Country { Name = "Italy" } }
            }),
            (new CheckedListItem<League>
            {
                IsChecked = true,
                Item = new League { Name = "foo", Country = new Country { Name = "England" } }
            }) };
            this.DataContext = this;
        }
       
        public void CheckBoxCountry_Checked(object sender, EventArgs args)
        {
            foreach (CollectionViewGroup gp in CompetitionCombo.Items.Groups)
            {
                
                    //Get the container
                    GroupItem container = CompetitionCombo.ItemContainerGenerator.ContainerFromItem(gp) as GroupItem;
                //Get the control
                var control = FindVisualChildren<CheckBox>(container);
            }
        }
        public IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                        yield return (T)child;
                    foreach (T childOfChild in FindVisualChildren<T>(child))
                        yield return childOfChild;
                }
            }
        }
    }
