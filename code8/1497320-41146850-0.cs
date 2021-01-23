    public partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
            var dpd = DependencyPropertyDescriptor.FromProperty(LabelContentProperty, typeof(MyUserControl));
            dpd.AddValueChanged(this, (sender, args) =>
            {
                _label.Content = this.LabelContent;           
            });
        }
        public static readonly DependencyProperty LabelContentProperty = DependencyProperty.Register("LabelContent", typeof(string), typeof(MyUserControl));
        public string LabelContent
        {
            get 
            {
                return GetValue(LabelContentProperty) as string;
            }
            set 
            {
                SetValue(LabelContentProperty, value);
            }
        }
    }
