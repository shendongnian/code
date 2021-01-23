    public abstract class SearchListControl : UserControl
    {
        public SearchListControl()
        {
            InitializeComponent();
        }
        public DataTemplate DataTemplate
        {
            get { return lv.ItemTemplate; }
            set { lv.ItemTemplate = value; }
        }
    }
