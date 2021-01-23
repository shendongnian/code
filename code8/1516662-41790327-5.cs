    public class AutoCompleteBoxBehavior
    {
        public static ICommand GetSelectionChangedCommand(AutoCompleteTextBox actb)
        {
            return (ICommand)actb.GetValue(SelectionChangedCommandProperty);
        }
        public static void SetSelectionChangedCommand(AutoCompleteTextBox actb, ICommand value)
        {
            actb.SetValue(SelectionChangedCommandProperty, value);
        }
        public static readonly DependencyProperty SelectionChangedCommandProperty =
            DependencyProperty.RegisterAttached(
            "SelectionChangedCommand",
            typeof(ICommand),
            typeof(AutoCompleteBoxBehavior),
            new UIPropertyMetadata(null, OnHandleSelectionChangedEvent));
        private static void OnHandleSelectionChangedEvent(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ICommand command = e.NewValue as ICommand;
            if(command != null)
            {
                AutoCompleteTextBox actb = d as AutoCompleteTextBox;
                actb.Loaded += (ss, ee) =>
                {
                    ListBox lb = actb.Template.FindName("PART_ListBox", actb) as ListBox;
                    if (lb != null)
                    {
                        lb.SelectionChanged += (sss, eee) =>
                        {
                            command.Execute(null);
                        };
                    }
                };
            }
        }
    }
----------
    <ctrls:AutoCompleteTextBox
            Grid.Row="1"
            AutoCompleteQueryResultProvider="{Binding AutoCompleteQueryResultProvider}"
            Margin="10" FontSize="20" PopupHeight="300"
            local:AutoCompleteBoxBehavior.SelectionChangedCommand="{Binding YourCommand}">
     </ctrls:AutoCompleteTextBox>
