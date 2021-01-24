    public partial class MyList : ItemsControl {
        public MyList() {
            InitializeComponent();
        }
    }
    public class MyItem : ContentControl {
        public string Text {
            get {
                return (string)this.GetValue(TextProperty);
            }
            set {
                this.SetValue(TextProperty, value);
            }
        }
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(MyItem), new PropertyMetadata());
    }
