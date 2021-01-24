    public static DependencyProperty offsetChangeListener = DependencyProperty.RegisterAttached(
                                    "ListenerOffset",
                                    typeof(object),
                                    typeof(UserControl),
                                    new PropertyMetadata(OnScrollChanged));
