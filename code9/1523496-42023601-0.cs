        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            var dataObject = checkBox.DataContext as YourDataClass;
            if (dataObject.SomeProperty == true)
            {
                DataGridRow parentRow = FindParent<DataGridRow>(checkBox);
                if (parentRow != null)
                    parentRow.Visibility = Visibility.Collapsed;
            }
        }
        private static T FindParent<T>(DependencyObject dependencyObject) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(dependencyObject);
            if (parent == null) return null;
            var parentT = parent as T;
            return parentT ?? FindParent<T>(parent);
        }
