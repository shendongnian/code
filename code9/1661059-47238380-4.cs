    public partial class MyBaseForm<T> : Form
    {
        public MyBaseForm()
        {
            InitializeComponent();
        }
        BindingList<MySampleModel> someProperty = new BindingList<MySampleModel>();
        [Editor(typeof(MyUITypeEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [TypeConverter(typeof(CollectionConverter))]
        public BindingList<MySampleModel> SomeProperty
        {
            get { return someProperty; }
            set { someProperty = value; }
        }
        [Browsable(false)]
        public Type MyGenericType { get { return typeof(MySampleModel); } }
    }
