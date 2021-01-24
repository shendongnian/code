    public MyForm()
    {
        Initialize();
        Button MyOneTrickButton = new Button();
        //Create button with all attributes and actions
        ...
    }
    void MyTabControl_SelectedIndexChanged(object sender, EventArgs e)
    {
        MyTabControl.SelectedTab.Controls.Add(MyOneTrickButton);
    }
