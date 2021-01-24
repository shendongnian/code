    namespace WpfStackOverflow.Controls
    {
        /// <summary>
        /// Interaction logic for BasicMVVM.xaml
        /// </summary>
        public partial class BasicMVVM : UserControl
        {
            public BasicMVVM()
            {
               InitializeComponent();
               DataContext = new BasicMVVMViewModel();
            }
        }
    }
