    public static void DeSerializeXAML(UIElementCollection elements, string filename)
    {
        var context = System.Windows.Markup.XamlReader.GetWpfSchemaContext();
        var settings = new System.Xaml.XamlObjectWriterSettings
                           {
                               RootObjectInstance = elements
                           };
        using (var reader = new System.Xaml.XamlXmlReader(filename))
        using (var writer = new System.Xaml.XamlObjectWriter(context, settings))
        {
            System.Xaml.XamlServices.Transform(reader, writer);
        }
    }
    
    private void btnLoad_Click(object sender, RoutedEventArgs e)
    {
        Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
        dlg.DefaultExt = ".xaml"; // Default file extension
        dlg.Filter = "Xaml File (.xaml)|*.xaml"; // Filter files by extension
        // Show open file dialog box
        Nullable<bool> result = dlg.ShowDialog();
        // Process open file dialog box results
        if (result == true)
        {
            string filename = dlg.FileName;
            myCanvas.Children.Clear();
            DeSerializeXAML(myCanvas.Children, filename);
        }
    }
