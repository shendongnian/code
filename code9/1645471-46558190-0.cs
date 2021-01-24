    public override void OnApplyTemplate()
        {
            var btnButton= GetTemplateChild("btnButton") as Button;
            if (btnButton!= null)
                btnButton.Click += ButtonClick;
        }
        public event RoutedEventHandler ButtonClick;
        private void OnButtonClick(object sender, RoutedEventArgs e) { }
