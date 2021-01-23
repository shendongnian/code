    StringReader reader = new StringReader(
       @"<DataTemplate xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"">
       <Ellipse Width=""300.5"" Height=""200"" Fill=""Red""/>
       </DataTemplate>");
    var template = XamlReader.Load(await reader.ReadToEndAsync());
    ListView lv = new ListView();
    lv.ItemTemplate = template as DataTemplate;
    ObservableCollection<int> coll = new ObservableCollection<int>();
    for (int i = 0; i < 20; i++)
    {
        coll.Add(i);
    }
    lv.ItemsSource = coll;
    rootGrid.Children.Add(lv);
