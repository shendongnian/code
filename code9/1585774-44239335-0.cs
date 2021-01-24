    private void button1_Click(object sender, EventArgs e)
    {
        Class1 change = new Class1(this);
        change.ChangeLabelText();
    }
    public void ChangeLabel(string msg, Label label)
    {
        if (label.InvokeRequired)
            label.Invoke(new MethodInvoker(delegate { label.Text = msg; }));
        else
            label.Text = msg;
    }
    // dont allow UI elements to be accessed directly from outide
    public string Fullname
    {
        get
        {
            return label1.Text;
        }
        set
        {
            label1.Text = value;
        }
    }
    // dont allow UI elements to be accessed directly from outide
    public string Surname
    {
        get
        {
            return label2.Text;
        }
        set
        {
            label2.Text = value;
        }
    }
