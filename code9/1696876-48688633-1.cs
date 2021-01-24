    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;
    using FirstFloor.ModernUI.Windows.Controls;
    
    namespace WpfApp17
    {
        public partial class MainWindow : ModernWindow
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void ModernWindow_Loaded(object sender, RoutedEventArgs e)
            {
                var frame = VisualTreeHelperFindChildren<ModernFrame>(this).FirstOrDefault();
                if (frame != null)
                    frame.Navigating += Frame_Navigating;
            }
    
            private void Frame_Navigating(object sender, FirstFloor.ModernUI.Windows.Navigation.NavigatingCancelEventArgs e)
            {
                string dialog = "dialog:";
                if (e.Source.OriginalString.StartsWith(dialog))
                {
                    // Show dialog
                    var dialogName = e.Source.OriginalString.Remove(0, dialog.Length);
                    MessageBox.Show($"Show Dialog '{dialogName}'");
                    e.Cancel = true;
                }
            }
    
            public static List<T> VisualTreeHelperFindChildren<T>(DependencyObject parent) where T : class
            {
                List<T> list = new List<T>();
    
                if (parent != null)
                {
                    int count = VisualTreeHelper.GetChildrenCount(parent);
                    for (int i = 0; i < count; i++)
                    {
                        // Get object at index i
                        DependencyObject dobj = VisualTreeHelper.GetChild(parent, i);
    
                        if (dobj is T)
                        {
                            list.Add(dobj as T);
                        }
    
                        // Loop through its children
                        list.AddRange(VisualTreeHelperFindChildren<T>(dobj));
                    }
                }
                return list;
            }
    
        }
    }
