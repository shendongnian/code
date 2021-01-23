        public static IEnumerable<T> FindVisualChildByName<T>(DependencyObject parent, string name) where T : DependencyObject
        {
            List<T> list = new List<T>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                string controlName = child.GetValue(Control.NameProperty) as string;
                if (controlName == name)
                {
                    list.Add(child as T);
                }
                else
                {
                    IEnumerable<T> result = FindVisualChildByName<T>(child, name);
                    if (result != null)
                        list.AddRange(result);
                }
            }
            return list;
        }
