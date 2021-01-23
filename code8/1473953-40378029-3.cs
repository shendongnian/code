     private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var hub_section = FindVisualChildByName<HubSection>(this.myHub, "myHubSection");
            var text_box = FindVisualChildByName<WebView>(hub_section, "textbox1");
        }
        public static T FindVisualChildByName<T>(DependencyObject parent, string name)where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                string controlName = child.GetValue(Control.NameProperty) as string;
                if (controlName == name)
                {
                    return child as T;
                }
                else
                {
                    T result = FindVisualChildByName<T>(child, name);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }
    
