    public static class ButtonProperties
    {
        public static readonly DependencyProperty IncreaseDatePickerProperty =
            DependencyProperty.RegisterAttached(
                "IncreaseDatePicker",
                typeof(DatePicker),
                typeof(ButtonProperties),
                new UIPropertyMetadata(IncreaseDatePickerPropertyChanged));
        public static DatePicker GetIncreaseDatePicker(Button b)
        {
            return (DatePicker)b.GetValue(IncreaseDatePickerProperty);
        }
        public static void SetIncreaseDatePicker(Button b, DatePicker value)
        {
            b.SetValue(IncreaseDatePickerProperty, value);
        }
        private static void IncreaseDatePickerPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            Button b = (Button)sender;
            b.Click -= B_Click;
            b.Click += B_Click;
        }
        private static void B_Click(object sender, RoutedEventArgs e)
        {
            DatePicker picker = GetIncreaseDatePicker((Button)sender);
            picker.SelectedDate = picker.SelectedDate.Value.AddDays(1);
        }
    }
