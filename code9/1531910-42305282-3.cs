    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    
    namespace WpfApplication1
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
                SizeChanged += MainWindow_SizeChanged;
            }
    
            private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
            {
                var viewer = GetChildOfType<ScrollViewer>(Box);
                if (viewer != null)
                {
                    Debug.WriteLine(viewer.ComputedVerticalScrollBarVisibility);
                }
            }
    
            public static T GetChildOfType<T>(DependencyObject depObj)
                where T : DependencyObject
            {
                if (depObj == null)
                    return null;
    
                for (var i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    var child = VisualTreeHelper.GetChild(depObj, i);
    
                    var result = child as T ?? GetChildOfType<T>(child);
                    if (result != null)
                        return result;
                }
                return null;
            }
        }
    }
