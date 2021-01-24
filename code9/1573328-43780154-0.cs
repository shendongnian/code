    //a loop uses ';', not ','
    for (int i = 0; i < 54; i++)
    {
        //declare a new dynamic textbox = CaSe SeNsItIvE
        TextBox TestTextbox = new TextBox();
        TestTextbox.ID = "Reg" + i;
    
        //if you want to add attibutes you do it like this
        TestTextbox.AutoPostBack = true;
        TestTextbox.TextChanged += TestTextbox_TextChanged;
    
        //add the textbox to the page
        PlaceHolder1.Controls.Add(TestTextbox);
    }
