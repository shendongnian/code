     class WebBrowserExtension
        {
    
        #region BindableSourceProperty
        public static readonly DependencyProperty BindableSourceProperty =
        DependencyProperty.RegisterAttached("BindableSource", typeof(string), typeof(WebBrowserExtension), new UIPropertyMetadata("", BindableSourcePropertyChanged));
        public static string GetBindableSource(DependencyObject obj)
        {
            return (string)obj.GetValue(BindableSourceProperty);
        }
        public static void SetBindableSource(DependencyObject obj, string value)
        {
            obj.SetValue(BindableSourceProperty, value);
        }
        public static void BindableSourcePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            WebBrowser browser = o as WebBrowser;
            if (browser != null)
            {
                string uri = e.NewValue as string;
                browser.Source = !String.IsNullOrEmpty(uri) ? new Uri(uri) : null;
            }
        }
        #endregion
    
            #region NavigatingCmdExtended
    
            public static ICommand GetNavigatingCmdExtended(DependencyObject obj)
            {
                return (ICommand)obj.GetValue(NavigatingCmdExtendedProperty);
            }
            public static void SetNavigatingCmdExtended(DependencyObject obj, ICommand value)
            {
                obj.SetValue(NavigatingCmdExtendedProperty, value);
            }
            // Using a DependencyProperty as the backing store for CalenderOpenCommand. This enables animation, styling, binding, etc...
            public static readonly DependencyProperty NavigatingCmdExtendedProperty =
            DependencyProperty.RegisterAttached("NavigatingCmdExtended", typeof(ICommand), typeof(WebBrowserExtension), new PropertyMetadata(OnChangedNavigatingCmdExtendedProperty));
    
    
            private static void OnChangedNavigatingCmdExtendedProperty(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var webBrowser = d as WebBrowser;
                if (webBrowser != null)
                {
                    if (e.NewValue != null)
                    {
                        //attach event handler
                        webBrowser.Navigating += webBrowser_Navigating;
                    }
                    else
                    {
                        //detach event handler
                        webBrowser.Navigating -= webBrowser_Navigating;
                    }
                }
            }
            ///
            /// Event handler for Calender Opened event.
            ///
            ///
            ///
            static void webBrowser_Navigating(object sender, NavigatingCancelEventArgs e)
            {
                ICommand command = GetNavigatingCmdExtended(sender as DependencyObject);
                if (command != null)
                {
                    if (command.CanExecute(e))
                    {
                        //executes a command
                        command.Execute(e);
                    }
                }
            }
            #endregion
