    private void themeSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        AssemblyName assemblyName = Assembly.GetAssembly(this.GetType()).GetName();
        ResourceDictionary dictionary = (ResourceDictionary)Application.LoadComponent(
            new Uri(assemblyName.Name + @";component/" + cboTheme.SelectedItem + ".xaml", UriKind.Relative))));
        App.Current.Resources.MergedDictionaries.Clear();
        if (dictionary != null)
        {
            App.Current.Resources.MergedDictionaries.Add(dictionary);
        }
    }
