    public partial class FileLink : UserControlBase
    {
        public FileLink()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty FileNameProperty =
            DependencyProperty.Register(nameof(FileName), typeof(string), typeof(FileLink));
        public string FileName
        {
            get { return (string)GetValue(FileNameProperty); }
            set { SetValue(FileNameProperty, value); }
        }
    }
