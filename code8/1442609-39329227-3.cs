    namespace WpfApplication9
    {
        public class BaseControl : UserControl
        {
            public BaseControl()
            {
                
            }
        public override void EndInit()
        {
            base.EndInit();
            ExtTextBlock block = new ExtTextBlock { Width = 100 , Height = 20 , Text = "Test Block" };
            ExtButton button = new ExtButton { Width = 100, Height = 20 , Content = "ClickMe"};
            ExtLabel label = new ExtLabel { Width = 100, Height = 30 ,Content = "Test Label"};
            ExtTextBox txtBox = new ExtTextBox { Width = 100, Height = 20 ,Text= "Hi There"};
            Grid g = (Grid)BaseControl.FindChild(this, "gridMain");
            g.Children.Add(button);
            g.Children.Add(block);
            g.Children.Add(label);
            g.Children.Add(txtBox);
            Grid.SetRow(block, 0);
            Grid.SetRow(button, 1);
            Grid.SetRow(label, 2);
            Grid.SetRow(txtBox, 3);
            button.Click += button_Click;
        }
        void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi There");
        }
        public static DependencyObject FindChild(DependencyObject parent, string name)
        {
            // confirm parent and name are valid.
            if (parent == null || string.IsNullOrEmpty(name)) return null;
            if (parent is FrameworkElement && (parent as FrameworkElement).Name == name) return parent;
            DependencyObject result = null;
            if (parent is FrameworkElement) (parent as FrameworkElement).ApplyTemplate();
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                result = FindChild(child, name);
                if (result != null) break;
            }
            return result;
        }
        /// <summary>
        /// Looks for a child control within a parent by type
        /// </summary>
        public static T FindChild<T>(DependencyObject parent)
            where T : DependencyObject
        {
            // confirm parent is valid.
            if (parent == null) return null;
            if (parent is T) return parent as T;
            DependencyObject foundChild = null;
            if (parent is FrameworkElement) (parent as FrameworkElement).ApplyTemplate();
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                foundChild = FindChild<T>(child);
                if (foundChild != null) break;
            }
            return foundChild as T;
        }
    }
    }
    
    namespace WpfApplication9.Foo
    {
        public class ExtTextBlock : TextBlock { }
        public class ExtTextBox : TextBox { }
    }
    
    namespace WpfApplication9.Bar
    {
        public class ExtButton : Button { }
        public class ExtLabel : Label { }
    }
