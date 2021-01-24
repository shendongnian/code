    public class CustomLabelCell : ViewCell
    {
        private Label label;
        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(CustomLabelCell), null);
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        // disable public set on View property
        public new View View
        {
            get { return base.View; }
            private set { base.View = value; }
        }
        public CustomLabelCell()
        {
            this.label = new Label()
            {
                Text = this.Text
            };
            ContentView frame = new ContentView()
            {
                Padding = new Thickness(4.0),
                Content = label
            };
            this.View = frame;
        }
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == TextProperty.PropertyName)
            {
                this.label.Text = this.Text;
                ForceUpdateSize();
            }
        }
    }
