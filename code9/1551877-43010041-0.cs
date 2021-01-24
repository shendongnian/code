    int b = 1;
    Label labelOnForm;
    public Form1()
    {
        InitializeComponent();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        if (labelOnForm != null)
        {
           this.Controls.Remove(labelOnForm);
           labelOnForm.Dispose();
        }
        Label label = new Label(); // used to print users
        label.Text = String.Format("{0}", b);
        label.Left = 10;
        label.Top =  25;
        this.Controls.Add(label);
        labelOnForm = label;
        b = b + 1;
        Console.WriteLine(b);
    }
