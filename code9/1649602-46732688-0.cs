    private void btnStart_Click(object sender, RoutedEventArgs e)
    {
        string path = "";
        OpenFileDialog ofd = new OpenFileDialog();
        ofd.Filter = "Properties | *.properties";
        if (ofd.ShowDialog() == true)
        {
            path = ofd.FileName;
        }
        List<ServerProperties> serverProperties = new List<ServerProperties>();
        using (StreamReader sr = new StreamReader(path))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (!line.StartsWith("#"))
                {
                    string[] lines = line.Split('=');
                    string property = lines[0];
                    string value = lines[1];
                    serverProperties.Add(new ServerProperties { Property = property, Value = value });
                    Debug.Print($"Property: {property} Value: {value}");
                }
            }
        }
        dgItems.ItemsSource = serverProperties;
    }
