     public DisplayForm(int id, string name, string address)
    {
        InitializeComponent();
        //Take the data that you passed to the constructor, and use it to update the text boxes:
        txtID.Text = id.ToString();
        txtName.Text = name;
        txtAddress.Text = address;
    }
