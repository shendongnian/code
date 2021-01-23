    public MainWindow()
    {
        InitializeComponent();
        ListBox.ItemsSource = Load();
    }
    public List<Person> Load()
    {
        XmlDocument xDoc = new XmlDocument();
        xDoc.Load("UsersList");
        XmlElement xRoot = xDoc.DocumentElement;
        List<Person> users = new List<Person>();
        foreach (XmlNode xnode in xRoot)
        {
            Person user = new Person();
            if (xnode.Attributes.Count > 0)
            {
                XmlNode attr = xnode.Attributes.GetNamedItem("name");
                if (attr != null)
                    user.Name = attr.Value;
            }
            foreach (XmlNode childnode in xnode.ChildNodes)
            {
                if (childnode.Name == "images")
                {
                    user.Images = childnode.InnerText;
                }
                if (childnode.Name == "age")
                {
                    user.Age = childnode.InnerText;
                }
            }
            users.Add(user);
        }
        return users;
    }
