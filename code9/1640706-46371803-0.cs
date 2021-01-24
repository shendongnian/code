    // In Constructor
    button1.Tag = textbox1;
    button1.Click += AllButtons_Click;
    button2.Tag = textbox2;
    button2.Click += AllButtons_Click;
    // Then you can access textboxex from the event
    private void AllButtons_Click(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var textbox = (TextBox)button.Tag;
        buttonLogic(textbox);
    }
