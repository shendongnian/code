    public ListEcoles()
    {
        InitializeComponent();
        List<string> listEcoles = MainWindow._RE.ListEcoles();
        foreach (string nomEcole in listEcoles)
            listEcole.Links.Add(new Link() { DisplayName = nomEcole, Source = new Uri("/Controles/EcoleControl.xaml", UriKind.Relative) });
        listEcole.PreviewMouseLeftButtonUp += ListEcole_MouseLeftButtonUp;
    }
    private void ListEcole_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        ListBoxItem lbi = e.OriginalSource as ListBoxItem;
        if (lbi == null)
        {
            lbi = FindParent<ListBoxItem>(e.OriginalSource as DependencyObject);
        }
        if (lbi != null)
        {
            Link selectedLink = lbi.DataContext as Link;
            if (selectedLink != null)
            {
                string selectedDisplayName = selectedLink.DisplayName;
                MessageBox.Show(selectedDisplayName);
            }
        }
    }
    private static T FindParent<T>(DependencyObject dependencyObject) where T : DependencyObject
    {
        var parent = VisualTreeHelper.GetParent(dependencyObject);
        if (parent == null) return null;
        var parentT = parent as T;
        return parentT ?? FindParent<T>(parent);
    }
