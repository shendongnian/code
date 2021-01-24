    public static class ActivePages
        {
            private static Uri mainFramePage;
            private static Uri headerFramePage;
    
            public static Uri MainFramePage
            {
                get { return mainFramePage; }
                set
                {
                    mainFramePage = value;
                    if (value == SignIn)
                    {
                        HeaderFramePage = EmptyHeader;
                    }
                    OnPropertyChanged(new PropertyChangedEventArgs("MainFramePage"));            }
            }
            public static Uri HeaderFramePage
            {
                get { return headerFramePage; }
                set
                {
                    headerFramePage = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("HeaderFramePage"));
                }
            }
            public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;
            static ActivePages()
            {
                SignIn = new Uri("Pages/SignIn.xaml",UriKind.Relative);
            }
            private static void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                if (StaticPropertyChanged != null)
                {
                    StaticPropertyChanged(null, e);
                }
            }
        }
      
