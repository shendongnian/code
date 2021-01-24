    public Form1()
    {
    InitializeComponent();
    }
    public void Form1_Load()
    {
        LoadDGV();
    }
    public void LoadDGV()
    {
    //create and populate DGV
    //Count columns first, prevents existing columns being duplicated and left 
    //blank after updates
    }
    private void Update_Click(object sender, EventArgs e)
    {
    Form2 form2 = new Form2(this);
    form2.Show();
    }
