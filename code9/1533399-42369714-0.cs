    public partial class MainWindow : Window
    {
        private List<StackPanel> _theItems = new List<StackPanel>();
        public MainWindow()
        {
            InitializeComponent();
	    //create the items:
            StackPanel sp1 = new StackPanel();
            ListBoxItem lbi1 = new ListBoxItem() { Content = "b" };
            Image img1 = new Image();
            sp1.Children.Add(lbi1);
            sp1.Children.Add(img1);
            _theItems.Add(sp1);
            StackPanel sp2 = new StackPanel();
            ListBoxItem lbi2 = new ListBoxItem() { Content = "a" };
            Image img2 = new Image();
            sp2.Children.Add(lbi2);
            sp2.Children.Add(img2);
            _theItems.Add(sp2);
            StackPanel sp3 = new StackPanel();
            ListBoxItem lbi3 = new ListBoxItem() { Content = "c" };
            Image img3 = new Image();
            sp3.Children.Add(lbi3);
            sp3.Children.Add(img3);
            _theItems.Add(sp3);
            //sort the items by the Content property of the ListBoxItem
            lb.ItemsSource = _theItems.OrderBy(x => x.Children.OfType<ListBoxItem>().FirstOrDefault().Content.ToString()).ToList();
        }
    }
