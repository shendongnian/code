    public MainWindow()
    {
        InitializeComponent();
        //the dictionary
        Dictionary<string, List<Person>> m_PersionDict = new Dictionary<string, List<Person>>();
        m_PersionDict.Add("Male", new List<Person>()
                {
                    new Person() { Name = "John Doe", Age = 42 },
                    new Person() { Name = "Sammy Doe", Age = 13 }
                });
        m_PersionDict.Add("Female", new List<Person>()
                {
                    new Person() { Name = "Jane Doe", Age = 39 }
                });
        var flattened = m_PersionDict.SelectMany(x => x.Value.Select(y => new { Key = x.Key, Name = y.Name, Age = y.Age })).ToList();
        lv.ItemsSource = flattened;
        CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lv.ItemsSource);
        PropertyGroupDescription groupDescription = new PropertyGroupDescription("Key");
        view.GroupDescriptions.Add(groupDescription);
    }
