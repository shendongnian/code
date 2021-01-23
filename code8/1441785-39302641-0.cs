    const int NAME_MAX_CHARACTERS = 15;
	
    public mainForm()
    {
        InitializeComponent();
    }
    private void addButton_Click(object sender, EventArgs e)
    {
		if(!Validate())
		{
			return;
		}
		
        // I need to check if the content is valid before adding it to the form
        ListViewItem item = new ListViewItem(this.nameTextBox.Text);
        this.listView1.Items.Add(item);
    }
    private void nameTextBox_Validating(object sender, CancelEventArgs e)
    {
		e.Cancel = !Validate();
    }
	
	private bool Validate()
	{
        string nameText = nameTextBox.Text;
		if(String.IsNullOrEmpty(nameText))
		{
			this.mainFormErrorProvider.SetError(this.nameTextBox, "I am sorry but the name cannot be empty");
			return false;
		}
		
		if(nameText.Contains(" "))
		{
			this.mainFormErrorProvider.SetError(this.nameTextBox, "I am sorry but the name cannot contain spaces");
			return false;
		}
		
        if (nameText.Length > 15)
        {
			this.mainFormErrorProvider.SetError(this.nameTextBox, "I am sorry, but the name cannot have more than " + NAME_MAX_CHARACTERS + " characters");
            return false;
        }
		
		return true;
	}
