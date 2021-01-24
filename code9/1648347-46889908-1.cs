        public static readonly DependencyProperty UserAccessProperty = 
            DependencyProperty.RegisterAttached(
                "UserAccessType",
                typeof(Dictionary<string, UserConfiguration>),
                typeof(UserAccess),
                new PropertyMetadata(
                    new PropertyChangedCallback(UserAcccessnChanged)));
