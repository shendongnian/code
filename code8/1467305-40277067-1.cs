    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Media;
    
    namespace WpfStackOverflow
    {
        /// <summary>
        /// Interaction logic for Window12.xaml
        /// </summary>
        public partial class Window12 : Window
        {
            public Window12()
            {
                InitializeComponent();
            }
    
            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                var c = VisualTreeHelper.GetClip(sender as Button);
                Pth.Data = c;
            }
    
            double scaleX=1, scaleY=1;
            private void Thumb_DragDelta_1(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
            {
                if (Pth.LayoutTransform == null)
                    Pth.LayoutTransform = new ScaleTransform(1, 1);
    
                scaleX += e.HorizontalChange;
                scaleY += e.HorizontalChange;
    
                Pth.LayoutTransform = new ScaleTransform(scaleX, scaleY);
    
                System.Diagnostics.Debug.WriteLine((1 + e.HorizontalChange).ToString());
                Thickness margin = (sender as Thumb).Margin;
                (sender as Thumb).Margin = new Thickness(margin.Left + e.HorizontalChange, margin.Top, margin.Right, margin.Bottom);
            }
        }
    }
