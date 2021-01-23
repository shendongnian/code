        /// <summary>
        /// Find first ascendant control of a specified type.
        /// </summary>
        /// <typeparam name="T">Type to search for.</typeparam>
        /// <param name="element">Child element.</param>
        /// <returns>Ascendant control or null if not found.</returns>
        public static T FindAscendant<T>(this FrameworkElement element)
            where T : FrameworkElement
        {
            if (element.Parent == null)
            {
                return null;
            }
            if (element.Parent is T)
            {
                return element.Parent as T;
            }
            return (element.Parent as FrameworkElement).FindAscendant<T>();
        }
        /// <summary>
        /// Find first visual ascendant control of a specified type.
        /// </summary>
        /// <typeparam name="T">Type to search for.</typeparam>
        /// <param name="element">Child element.</param>
        /// <returns>Ascendant control or null if not found.</returns>
        public static T FindVisualAscendant<T>(this FrameworkElement element)
            where T : FrameworkElement
        {
            var parent = VisualTreeHelper.GetParent(element);
            if (parent == null)
            {
                return null;
            }
            if (parent is T)
            {
                return parent as T;
            }
            return (parent as FrameworkElement).FindVisualAscendant<T>();
        }
