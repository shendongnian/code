    namespace ListView
    {
        using System.Windows;
        using System.Windows.Controls;
    
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private bool skipSelectionChanged;
    
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (skipSelectionChanged)
                {
                    skipSelectionChanged = false;
    
                    return;
                }
    
                var listView = sender as ListView;
    
                if (listView != null)
                {
                    var name = listView.Name;
                    for (int i = 0; i < MyStackPanel.Children.Count; i++)
                    {
                        var child = MyStackPanel.Children[i] as ListView;
                        if (child.Name != name && child.SelectedItem != null)
                        {
                            skipSelectionChanged = true;
                            child.SelectedItem = null;
                        }
                    }
                }
            }
        }
    }
