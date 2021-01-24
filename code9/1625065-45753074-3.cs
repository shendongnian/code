    public partial class Buttons : UserControl
    {
        public Buttons()
        {
            Options = new ObservableCollection<Button>();
            InitializeComponent();
        }
        public ObservableCollection<Button> Options
        {
            get { return (ObservableCollection<Button>) GetValue(OptionsProperty); }
            set { SetValue(OptionsProperty, value); }
        }
        public static readonly DependencyProperty OptionsProperty =
            DependencyProperty.Register("Options", typeof(ObservableCollection<Button>), typeof(Buttons));    
    }
