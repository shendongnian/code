    public UserInputForm()
    {
        InitializeComponent();
        btnAdd.Click += btnAdd_Click;
    }
    public void btnAdd_Click(object sender, EventArgs E)
    {
        Form2 parent = (this.Parent as Form2);
        parent.charList.Add(txtName.Text);
        this.Close();
    }
