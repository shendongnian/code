    public class SelectFirstItemBehavior : Behavior<ComboBox>
    {
        protected override void OnAttached()
        {
            AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.SelectionChanged -= AssociatedObject_SelectionChanged;
            base.OnDetaching();
        }
        private void AssociatedObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combobox = sender as ComboBox;
            if (combobox != null && combobox.SelectedIndex == -1)
            {
                combobox.SelectedIndex = 0;
            }
        }
    }
