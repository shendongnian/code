    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    
    
    namespace ListViewScroll
    {
        public partial class MainWindow : Window
        {
            public ObservableCollection<string> Names { get; set; }
    
            public MainWindow()
            {
                InitializeComponent();
                Names = new ObservableCollection<string>();
                ListView.ItemsSource = Names;
            }
    
            private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
            {
                Names.Add("Some Name" + ++someInt);
                // Get the border of the listview (first child of a listview)
                var border = VisualTreeHelper.GetChild(ListView, 0) as Decorator;
    
                // Get scrollviewer
                var scrollViewer = border.Child as ScrollViewer;
                scrollViewer.ScrollToBottom();
            }
    
            private static int someInt;
        }
    }
