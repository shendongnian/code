       #region Properties       
        public string Test
        {
            get { return (string)GetValue(TestProperty); }
            set { SetValue(TestProperty, value); }
        }
        #endregion Properties
        #region Dependency Properties
        public static readonly System.Windows.DependencyProperty TestProperty =
           System.Windows.DependencyProperty.Register("Test", typeof(string), typeof(YourUserControl), new System.Windows.FrameworkPropertyMetadata() { BindsTwoWayByDefault = true });
        #endregion Dependency Properties
