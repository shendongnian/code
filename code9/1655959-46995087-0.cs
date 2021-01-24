    public partial class MyBaseForm<T> : Form
    {
        public MyBaseForm()
        {
            InitializeComponent();
        }
        [Editor(typeof(MyUITypeEditor), typeof(UITypeEditor))]
        public string SomeProperty { get; set; }
        [Browsable(false)]
        public Type MyGenericType { get { return typeof(T); } }
    }
