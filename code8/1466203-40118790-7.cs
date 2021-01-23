    namespace My.Project
    {
        public static class Properties
        {
            public static readonly BindableProperty EnableScrolling = BindableProperty.Create
            (
                "EnableScrolling",
                typeof(bool),
                typeof(WebView),
                true
            );
        }
    }
