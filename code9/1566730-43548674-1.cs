    using System;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApplication7
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private static Label FindClickedItem(object sender)
            {
                var mi = sender as MenuItem;
                if (mi == null)
                {
                    return null;
                }
    
                var cm = mi.CommandParameter as ContextMenu;
                if (cm == null)
                {
                    return null;
                }
    
                return cm.PlacementTarget as Label;
            }
    
            private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
            {
                listConnections.Children.Add(new Label
                {
                    Content = "New Connection",
                    ContextMenu = (ContextMenu)Resources["contextMenu"]
                });
            }
    
            private void View_OnClick(object sender, RoutedEventArgs e)
            {
                var clickedItem = FindClickedItem(sender);
                if (clickedItem != null)
                {
                    MessageBox.Show(" Viewing: " + clickedItem.Content);
                }
            }
    
            private void Edit_OnClick(object sender, RoutedEventArgs e)
            {
                var clickedItem = FindClickedItem(sender);
                if (clickedItem != null)
                {
                    string newName = "Connection edited on " + DateTime.Now.ToLongTimeString();
                    string oldName = Convert.ToString(clickedItem.Content);
                    clickedItem.Content = newName;
                    MessageBox.Show(string.Format("Changed name from '{0}' to '{1}'", oldName, newName));
                }
            }
    
            private void Delete_OnClick(object sender, RoutedEventArgs e)
            {
                var clickedItem = FindClickedItem(sender);
                if (clickedItem != null)
                {
                    string oldName = Convert.ToString(clickedItem.Content);
                    listConnections.Children.Remove(clickedItem);
                    MessageBox.Show(string.Format("Removed '{0}'", oldName));
                }
            }
        }
    }
