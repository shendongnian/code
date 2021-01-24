    private void themeSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string theme = cboTheme.SelectedItem.ToString();
        App.Current.Resources.MergedDictionaries.Clear();
        App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("Theme" + theme + ".xaml", UriKind.RelativeOrAbsolute) });
        // Save Theme for next launch
        Settings.Default["Theme"] = theme;
        Settings.Default.Save();
    }
