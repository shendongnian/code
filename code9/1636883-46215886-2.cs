    public Form1()
    {
        InitializeComponent();
        formB = new Form2 { Owner = this };
        formC = new Form2 { Owner = this };
        formB.VisibleChanged += Child_VisibleChanged;
        formC.VisibleChanged += Child_VisibleChanged;
    }
    void Child_VisibleChanged(object sender, EventArgs e)
    {
        if (!Application.OpenForms.Cast<Form>().OfType<Form2>().Any(o => o.Visible))
            Activate();
    }
