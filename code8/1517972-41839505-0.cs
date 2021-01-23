    public partial class AbstractDictionaryPickerView : UserControl
    {
        public AbstractDictionaryPickerView()
        {
            InitializeComponent();
        }
        public ViewBase GridView
        {
            get { return SearchResultsList.View; }
            set { SearchResultsList.View = value; }
        }
    }
