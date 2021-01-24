    namespace WpfApplication29
    {
        /// <summary>
        /// Interaction logic for LinqView.xaml
        /// </summary>
        public partial class LinqView : UserControl
        {
            public LinqView()
            {
                InitializeComponent();
            }
    
            private void MenuItem_VU(object sender, RoutedEventArgs e)
            {
                (this.DataContext as LinqViewModel).SelectedChildModel = (this.DataContext as LinqViewModel).UserModel;
            }
        }
    }
