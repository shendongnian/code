    FirstForm ParentForm { get; set; }
    
    public SecondForm(FirstForm parent)
    {
        InitializeComponent();
        this.ParentForm = parent; // store the reference for later use
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        ParentForm.Name = txtName.Text; // set a public property on the parent form
        ParentForm.Address = txtAddress.Text;
    
    }
