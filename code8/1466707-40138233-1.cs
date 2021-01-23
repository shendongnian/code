    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person { Id = 1, Name = "Some Name" });
            persons.Add(new Person { Id = 2, Name = "Other Name" });
            ViewState["Persons"] = persons;
            ListBox1.DataSource = persons;
            ListBox1.DataTextField = "Name";
            ListBox1.DataValueField = "Id";
            ListBox1.DataBind();
        }
    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<Person> persons = (List<Person>)ViewState["Persons"];
        Person person = persons[ListBox1.SelectedIndex];
    }
