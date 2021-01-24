    namespace WpfApplication1
    {    
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private bool flag = false;
            private void Circle_button_OnMouseDown(object sender, MouseButtonEventArgs e)
            {
                if (flag)
                {
                    var storyboard = this.Resources["ElipseStoryboard"] as Storyboard;
                    if (storyboard != null)
                        storyboard.Begin(circle_button);
                }
                else
                {
                    var storyboard = this.Resources["ElipseStoryboardReversed"] as Storyboard;
                    if (storyboard != null)
                        storyboard.Begin(circle_button);
                }
                flag = !flag;
            }
        }
    }
