    if(displayListboxForm == true)
    {
        var listboxForm = new ListboxForm();
        //subscribing to the click event
        listboxForm.button1.Click += YourMethod;
        listboxForm.ShowDialog();
    
        // Now I want MainForm to wait until the user clicks DoneButton in ListboxForm
        MessageBox.Show("User has selected an option from ListboxForm");
    }
    
    public void YourMethod(EventArgs e)
    {
       //your logic here when the button is clicked
    }
