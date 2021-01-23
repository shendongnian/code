    public string UserName
    {
        get
        {
            return textBox1.Text;
        }
    }
    // Then you can use it like this (where Form2 is an instance of the logon form)
    string currentUser = Form2.UserName;
