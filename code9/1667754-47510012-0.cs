    public class FooTabItem : TabItem
    {
        public FooTabItem()
        {
            Buttons = new List<Button>();
        }
        public static readonly DependencyProperty ButtonsProperty =
            DependencyProperty.Register("Buttons", typeof(List<Button>), typeof(FooTabItem));
        public List<Button> Buttons
        {
            get { return (List<Button>)GetValue(ButtonsProperty); }
            set { SetValue(ButtonsProperty, value); }
        }
    }
