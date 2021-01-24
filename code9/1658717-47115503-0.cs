    public void Form_Load(object sender, EventArgs e)
    {
        proceed.Click += MyClickEvent1;
        proceed.Click += MyClickEvent2;
    }
    
    public void MyClickEvent1(object sender, EventArgs e)
    {
        // Do Stuff ...
    }
    public void MyClickEvent2(object sender, EventArgs e)
    {
        // Do More Stuff ...
    }
