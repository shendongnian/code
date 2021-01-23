       private void colorPicker_Loaded(object sender,RoutedEventArgs e)
        {
            Popup popup = FindVisualChildByName<Popup> ((sender as DependencyObject),"PART_ColorPickerPalettePopup");
            Border border = FindVisualChildByName<Border> (popup.Child,"DropDownBorder");
            border.Background = Brushes.Yellow;
        }
        private T FindVisualChildByName<T>(DependencyObject parent,string name) where T:DependencyObject
        {
            for (int i = 0;i < VisualTreeHelper.GetChildrenCount (parent);i++)
            {
                var child = VisualTreeHelper.GetChild (parent,i);
                string controlName = child.GetValue (Control.NameProperty) as string;
                if (controlName == name)
                {
                    return child as T;
                }
                else
                {
                    T result = FindVisualChildByName<T> (child,name);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }
