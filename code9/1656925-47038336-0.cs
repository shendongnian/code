    public bool IsCellSelected
        {
            get { return (bool)GetValue(IsCellSelectedProperty); }
            set { SetValue(IsCellSelectedProperty, value); }
        }
        public static readonly DependencyProperty IsCellSelectedProperty =
            DependencyProperty.Register("IsCellSelected", typeof(bool), typeof(RowHeaderButton), new PropertyMetadata(null));
