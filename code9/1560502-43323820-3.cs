    private Form1 _OpenerForm;
    public string productName = "";
    public Form2(Form1 OpenerForm)
    {
       _OpenerForm = OpenerForm;
       InitializeComponent();
    }
    private void Form2_Load(object sender, EventArgs e)
    {
        textBox1.Text = productName;
    }
    private void submitButton_Click(object sender, EventArgs e){
        _OpenerForm._ListView.Items[_OpenerForm._ListView.SelectedItems[0].Index].SubItems[0].Text = textBox1.Text;
    }
