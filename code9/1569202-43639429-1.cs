    public static class Extensions
    {
        private static Dictionary<Type, Action<UIElement>> controldefaults = new Dictionary<Type, Action<UIElement>>()
        {
            {typeof(TextBox), c => ((TextBox)c).Text = String.Empty},
            {typeof(CheckBox), c => ((CheckBox)c).IsChecked = false},
            {typeof(ComboBox), c => ((ComboBox)c).SelectedIndex = 0},
            {typeof(ListBox), c => ((ListBox)c).Items.Clear()},
            {typeof(RadioButton), c => ((RadioButton)c).IsChecked = false},
        };
        private static void FindAndInvoke(Type type, UIElement control)
        {
            if (controldefaults.ContainsKey(type))
            {
                controldefaults[type].Invoke(control);
            }
        }
        public static void ClearControls(this UIElementCollection controls)
        {
            foreach (UIElement control in controls)
            {
                FindAndInvoke(control.GetType(), control);
            }
        }
        public static void ClearControls<T>(this UIElementCollection controls) where T : class
        {
            if (!controldefaults.ContainsKey(typeof(T))) return;
            foreach (UIElement control in controls)
            {
                if (control.GetType().Equals(typeof(T)))
                {
                    FindAndInvoke(typeof(T), control);
                }
            }
        }
    }
