    private Form1 frm1;
    public Form2(Form1 frm1)
    {
        InitializeComponent();
        this.frm1 = frm1;
        try
        {
            foreach (object item in frm1.checkbox)
            {
                comboBox1.Items.Add(item);
            }
        }
        catch (System.Exception excep)
        {
            MessageBox.Show(excep.Message);
        }
    }
