    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    namespace WpfTest
    {
        /// <summary>
        /// Interaction logic for MainPage.xaml
        /// </summary>
        public partial class MainPage : Page
        {
            private Brush bCol;
            public static DependencyProperty BColProperty =DependencyProperty.Register("BCol", typeof(Brush),typeof(MainPage));
        public Brush BCol
        {
            get { return (Brush)this.GetValue(BColProperty); }
            set { this.SetValue(BColProperty, value); }
        }
        public MainPage()
            {
                InitializeComponent();
                BCol=new SolidColorBrush(Colors.Blue);
            }
        }
    }
