    public abstract class MyControlBase : UserControl
    {
        public delegate void StartPositionClickedEventHandler(object sender, EventArgs e);
        public event StartPositionClickedEventHandler StartPositionClicked;
        public string SomeProperty
        {
            get { return (string)GetValue(SomePropertyProperty); }
            set { SetValue(SomePropertyProperty, value); }
        }
        protected void StartPosition_Click(object sender, RoutedEventArgs e)
        {
            StartPositionClicked?.Invoke(this, EventArgs.Empty);
        }
        // Using a DependencyProperty as the backing store for SomeProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SomePropertyProperty =
            DependencyProperty.Register("SomeProperty", typeof(string), typeof(MyControlA), null);
    }
    public sealed partial class MyControlA : MyControlBase
    {
        // Class specific code
    }
