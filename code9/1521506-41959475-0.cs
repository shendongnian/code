    public partial class Extensions
    {
        public static readonly DependencyProperty SelectionChangedCommandProperty = DependencyProperty.RegisterAttached("SelectionChangedCommand", typeof(ICommand), typeof(Extensions), new UIPropertyMetadata((s, e) =>
        {
            var element = s as Selector;
            if (element != null)
            {
                element.SelectionChanged -= OnSelectionChanged;
                if (e.NewValue != null)
                {
                    element.SelectionChanged += OnSelectionChanged;
                }
            }
        }));
        public static ICommand GetSelectionChangedCommand(UIElement element)
        {
            return (ICommand)element.GetValue(SelectionChangedCommandProperty);
        }
        public static void SetSelectionChangedCommand(UIElement element, ICommand value)
        {
            element.SetValue(SelectionChangedCommandProperty, value);
        }
        private static void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var element = sender as Selector;
            var command = element.GetValue(SelectionChangedCommandProperty) as ICommand;
            if (command != null && command.CanExecute(element.SelectedItem))
            {
                command.Execute(element.SelectedItem);
                e.Handled = true;
            }
        }
    }
