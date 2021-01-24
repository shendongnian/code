    public class Email : Freezable
    {
        protected override Freezable CreateInstanceCore()
        {
            return new Email();
        }
        public string Body
        {
            get { return (string)GetValue(BodyProperty); }
            set { SetValue(BodyProperty, value); }
        }
        public static readonly DependencyProperty BodyProperty =
            DependencyProperty.Register("Body", typeof(string), typeof(Email));
    }
