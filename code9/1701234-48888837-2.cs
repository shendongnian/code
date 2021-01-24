        private void Preview_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                string tag = "0";
                IEnumerable<TextBox> elements = FindVisualChildren<TextBox>(this).Where(x => x.Tag != null && x.Tag.ToString() == tag);
                foreach (TextBox element in elements)
                {
                    FocusElement(element);
                }
            }
        }
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }
                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
        private void FocusElement(IInputElement element)
        {
            if (element != null)
            {
                Dispatcher.BeginInvoke
                (System.Windows.Threading.DispatcherPriority.ContextIdle,
                new Action(delegate ()
                {
                    Keyboard.Focus(element);
                }));
            }
        }
