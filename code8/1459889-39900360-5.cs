    class Class1 : DependencyObject {
        public Class2 OtherInstance { get; set; }
        public string Text1 {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text1", typeof(string), typeof(Class1),
            new PropertyMetadata(true, (o, args) => ((Class1)o).OtherInstance.Text2 = (string)args.NewValue));
    }
    class Class2 {
        private string _text2;
        public Class1 OtherInstance { get; set; }
        public string Text2 {
            get { return _text2; }
            set {
                _text2 = value;
                OtherInstance.Text1 = value;
            }
        }
    }
