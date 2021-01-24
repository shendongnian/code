    Slider sl;
    Label label1;
    Label label2;
    private void AllFour_Unchecked(object sender, RoutedEventArgs e)
    {
        label1 = new Label();
        label1.HorizontalAlignment = HorizontalAlignment.Center;
        sl = new Slider();
        sl.Minimum = 1;
        sl.Maximum = 4;
        sl.TickFrequency = 1;
        sl.IsSnapToTickEnabled = true;
        sl.SetResourceReference(Control.StyleProperty, "SliderStyle");
        sl.SetResourceReference(Slider.ForegroundProperty, "SliderSelectionRangeBackgroundBrush");
        label2 = new Label();
        label2.HorizontalAlignment = HorizontalAlignment.Center;
        label2.BorderBrush = new SolidColorBrush(Colors.Gray);
        label2.SetBinding(Label.ContentProperty, new Binding("Value") { Source = sl });
        Dispatcher.BeginInvoke(new Action(() =>
        {
            Upgrades.Children.Add(label1);
            Upgrades.Children.Add(sl);
            Upgrades.Children.Add(label2);
        }), System.Windows.Threading.DispatcherPriority.Background);
    }
    private void AllFour_Checked(object sender, RoutedEventArgs e)
    {
        Upgrades.Children.Remove(label1);
        Upgrades.Children.Remove(sl);
        Upgrades.Children.Remove(label2);
    }
