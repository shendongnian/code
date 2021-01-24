        public static DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(RepositoryContainer), new FrameworkPropertyMetadata(new PropertyChangedCallback(Title_Changed)));
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        private static void Title_Changed(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            RepositoryContainer thisClass = (RepositoryContainer)o;
            thisClass.SetTitle();
        }
        private void SetTitle()
        {
            //Put Instance Title Property Changed code here
        }
