    Service you = new Service();
    List<Service> selectedItems = new List<Service>();
    private string json;
    public MainPage()
    {
        this.InitializeComponent();
        ObservableCollection<Class3> items = new ObservableCollection<Class3>()
        {
            new Class3()
            {
                id="1",
                sname="name1"
            },
            new Class3()
             {
                id="2",
                sname="name2"
            },
            new Class3()
            {
                id="3",
                sname="name3"
            }
        };
        serviceListView.ItemsSource = items;
    }
    // check box code    
    private void Checkbox_Checked(object sender, RoutedEventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        string item = checkbox.DataContext.ToString();
        Service you = new Service();
        you.id = item;
        selectedItems.Add(you);
    }
    // submit button
    private void book_Click(object sender, RoutedEventArgs e)
    {
        string name = "name1";
        string email = "test@microsoft.com";
        string date = System.DateTime.Now.ToString();
        string description = "I'm the describtion";
        Rootobjectsss objnewobject = new Rootobjectsss()
        {
            customerName = name,
            email = email,
            appointmentDate = date,
            description = description,
            service = selectedItems.ToArray()
        };
        json = string.Empty;
        json = Newtonsoft.Json.JsonConvert.SerializeObject(objnewobject, Newtonsoft.Json.Formatting.Indented);
        Debug.WriteLine(json);
        //getData(json);
    }
    private void myCheckBox_Checked(object sender, RoutedEventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        foreach (Service removeitem in selectedItems)
        {
            if (removeitem.id == checkbox.DataContext.ToString())
            {
                selectedItems.Remove(removeitem);
                break;
            }
        }
    }
