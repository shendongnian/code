    public partial class HolderControl : UserControl
    {
        public HolderControl()
        {
            InitializeComponent();
        }
        public int? SelectedConditionId
        {
            get { return (int?)GetValue(SelectedConditionIdProperty); }
            set { SetValue(SelectedConditionIdProperty, value); }
        }
        // Using a DependencyProperty as the backing store for SelectedConditionId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedConditionIdProperty =
            DependencyProperty.Register("SelectedConditionId", typeof(int?), typeof(HolderControl), new FrameworkPropertyMetadata());
    }
