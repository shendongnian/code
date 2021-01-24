    public class Tab1 : UserControl
    {
        ...
        public Boolean HasAccess
        {
            get { return (Boolean)this.GetValue(HasAccessProperty); }
            set { this.SetValue(HasAccessProperty, value); }
        }
        public static readonly DependencyProperty HasAccessProperty = DependencyProperty.Register(
          "HasAccess", typeof(Boolean), typeof(Tab1), new PropertyMetadata(false));
    }
