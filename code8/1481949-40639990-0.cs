    private void RunTest()
    {
        Form myForm2 = new Form2();
        myForm2.otherform = this;              // <--- note this line
        myForm2.TopLevel = false;
        this.Controls.Add(myForm2);            // TODO: why is this line here?
        myForm2.Show();
    }
