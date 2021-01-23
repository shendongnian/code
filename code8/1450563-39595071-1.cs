        public ObservableCollection<TestTreeClass> TestTreeList
        {
            get { return (ObservableCollection<TestTreeClass>)GetValue(TestTreeListProperty); }
            set { SetValue(TestTreeListProperty, value); }
        }
        // Using a DependencyProperty as the backing store for TestTreeList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TestTreeListProperty =
            DependencyProperty.Register("TestTreeList", typeof(ObservableCollection<TestTreeClass>), typeof(MainWindow), new PropertyMetadata(null));
        TestTreeList = new ObservableCollection<TestTreeClass>()
            {
                new TestTreeClass() { Val1 = "AAA", Val2 = "111", Val3 = "abc" },
                new TestTreeClass() { Val1 = "AAA", Val2 = "111", Val3 = "def" },
                new TestTreeClass() { Val1 = "BBB", Val2 = "111", Val3 = "ghi" },
                new TestTreeClass() { Val1 = "BBB", Val2 = "111", Val3 = "jkl" },
                new TestTreeClass() { Val1 = "AAA", Val2 = "222", Val3 = "mno" }
    };
