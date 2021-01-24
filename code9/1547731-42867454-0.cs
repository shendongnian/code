    public class Parent : UserControl
    {
        [Category("Silo - appearance")]
        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(Color), typeof(Parent),
                new PropertyMetadata((Color)Color.FromArgb(255, 0x1A, 0x17, 0xA)));
        public Color SecondaryColor
        {
            get { return (Color)GetValue(SecondaryColorProperty); }
            set { SetValue(SecondaryColorProperty, value); }
        }
        
        public static readonly DependencyProperty SecondaryColorProperty =
            DependencyProperty.Register("SecondaryColor", typeof(Color), typeof(Parent), new PropertyMetadata(Color.FromArgb(255, 0x47, 0x17, 0x9E)));
    }
    public partial class UserControl1 : Parent
    {
        public UserControl1()
        {
            InitializeComponent();
        }       
    }
