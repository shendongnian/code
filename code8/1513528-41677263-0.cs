    class MainWindow:System.Windows.Window 
    {
        List<Person> lstPerson;
        public MainWindow()
        {
            InitializeComponent();
            lstPerson = new List<Person>();
            Load();
        }
        public void Load()
        {
            
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("UsersList");
            XmlElement xRoot = xDoc.DocumentElement;
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
                lstPerson.Add(user)
            }
            ListBox.itemsSource= lstPerson
        }
    }    
