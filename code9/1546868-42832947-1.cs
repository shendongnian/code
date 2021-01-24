    public Form1()
    {
    	InitializeComponent();
    	
    	var people = new BindingList<Person> {
    		new Person() { FirstName = "Peter", LastName = "Pan" },
    		new Person() { FirstName = "Tinker", LastName = "Bell" },
    		new Person() { FirstName = "James", LastName = "Hook" },
    		new Person() { FirstName = "Wendy", LastName = "Darling" },
    	};
    
    	var bindingSource = new BindingSource() { DataSource = people };
    
    	comboBoxPeople.DataSource = bindingSource;
    	textBoxFirstName.DataBindings.Add(nameof(TextBox.Text), bindingSource, nameof(Person.FirstName), false, DataSourceUpdateMode.OnPropertyChanged);
    	textBoxLastName.DataBindings.Add(nameof(TextBox.Text), bindingSource, nameof(Person.LastName), false, DataSourceUpdateMode.OnPropertyChanged);
    }
