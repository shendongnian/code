     public DisplayForm(DataGridViewRow row)
    {
        InitializeComponent();
        //Take the data that you passed to the constructor, and use it to update the text boxes:
        txtID.Text = row.Cells[0].Value.ToString();
        txtName.Text = row.Cells[1].Value.ToString();
        txtAddress.Text = row.Cells[2].Value.ToString();
    }
