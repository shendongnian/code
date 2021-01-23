    public class AutoCompleteBoxBehavior
    {
        public static bool GetHandleSelectionChangedEvent(AutoCompleteTextBox actb)
        {
            return (bool)actb.GetValue(HandleSelectionChangedEventProperty);
        }
        public static void SetHandleSelectionChangedEvent(AutoCompleteTextBox actb, bool value)
        {
            actb.SetValue(HandleSelectionChangedEventProperty, value);
        }
        public static readonly DependencyProperty HandleSelectionChangedEventProperty =
            DependencyProperty.RegisterAttached(
            "HandleSelectionChangedEvent",
            typeof(bool),
            typeof(AutoCompleteBoxBehavior),
            new UIPropertyMetadata(false, OnHandleSelectionChangedEvent));
        private static void OnHandleSelectionChangedEvent(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(e.NewValue != null && Convert.ToBoolean(e.NewValue))
            {
                AutoCompleteTextBox actb = d as AutoCompleteTextBox;
                actb.Loaded += (ss, ee) => 
                {
                    ListBox lb = actb.Template.FindName("PART_ListBox", actb) as ListBox;
                    if (lb != null)
                    {
                        lb.SelectionChanged += (sss, eee) =>
                        {
                            MainWindowViewModel vm = actb.DataContext as MainWindowViewModel;
                            //invoke a command of the view model or do whatever you want here...
                            var selectedItem = lb.SelectedItem;
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
                local:AutoCompleteBoxBehavior.HandleSelectionChangedEvent="True">
    </ctrls:AutoCompleteTextBox>
