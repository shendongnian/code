    public partial class ExtendedListBox : UserControl
    {
        public ExtendedListBoxDisplay DisplayAs { get; set; }
        public ExtendedListBox()
        {
            InitializeComponent();
            LstItems.ItemsSource = new List<ExtendedListBoxDisplay>() { new ExtendedListBoxDisplay() };
        }
    }
