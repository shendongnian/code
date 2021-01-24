    private void AddAndFilterButton_OnClick(object sender, RoutedEventArgs e)
        {
            var conditionUserControl = new ConditionUserControl();
            StackPanel.Children.Add(conditionUserControl);
            conditionUserControl.DeleteFilter.Click += (o, args) => StackPanel.Children.Remove(conditionUserControl);
        }
