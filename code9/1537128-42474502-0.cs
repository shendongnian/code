    // On Form 1
    private void Form1_Load(object sender, EventArgs e)
    {
        var frm = new Form2(this); // bein
        frm.Show();
    }
    public void GetValue(string Text)
    {
        // Do something
    }
    // On Form2
    private Form1 Form;
    public Form2(Form1 form)
    {
       InitializeComponent();
       this.Form1 = form;
       this.Form1.GetValue("Hi");
    }
