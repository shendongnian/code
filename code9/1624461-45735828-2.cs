        private static HashSet<string> _measuredWidthNamesSet = new HashSet<string>();
        private static void OnComboBoxLoaded(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (!_measuredWidthNamesSet.Contains(comboBox.Name))
            {
                Action action = () => { comboBox.SetWidthFromItems(_measuredWidthNamesSet); };
                comboBox.Dispatcher.BeginInvoke(action, DispatcherPriority.ContextIdle);
            }
        }
