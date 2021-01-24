    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var animationItem = new MyItem();
            this.DataContext = animationItem;
        }
      
        private void eventMarkerPath_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ((sender as FrameworkElement).DataContext as MyItem).CauseAnimation();
        }
    }
    public class MyItem
    {
        public void CauseAnimation()
        {
            if (this.AnimationTriggerEvent != null)
                this.AnimationTriggerEvent(this, null);
        }
        public event EventHandler AnimationTriggerEvent;
    }
