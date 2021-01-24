        public static T GetChildWithPath<T>(this DependencyObject depObj, DependencyProperty property = null, string pathName = null) where T : DependencyObject
        {
            T toReturn = null;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);
                bool pathNameMatch = (child is T) && child.IsPathNameMatch<T>(property, pathName);
                if (pathNameMatch)
                {
                    toReturn = child as T;
                    break;
                }
                else
                    toReturn = GetChildWithPath<T>(child, property, pathName);
                if (toReturn != null)
                    break;
            }
            return toReturn;
        }
